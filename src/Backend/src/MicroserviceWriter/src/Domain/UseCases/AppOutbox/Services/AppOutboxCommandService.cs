namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutbox.Services;

/// <summary>
/// Сервис исходящего сообщения приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_appOutgoingEventCommandService">Сервис команд исходящего события приложения.</param>
/// <param name="_appOutgoingEventQueryService">Сервис запросов исходящего события приложения.</param>
/// <param name="_appOutgoingEventPayloadCommandService">
/// Сервис команд полезной нагрузки исходящего события приложения.
/// </param>
public class AppOutboxCommandService(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppMessageProducer _appMessageProducer,
  IAppOutgoingEventCommandService _appOutgoingEventCommandService,
  IAppOutgoingEventQueryService _appOutgoingEventQueryService,
  IAppOutgoingEventPayloadCommandService _appOutgoingEventPayloadCommandService) : IAppOutboxCommandService
{
  /// <inheritdoc/>
  public async Task Produce(AppOutboxProduceCommand command, CancellationToken cancellationToken)
  {
    var events = await GetUnpublishedEvents(command.EventMaxCountToPublish, cancellationToken).ConfigureAwait(false);

    if (events.Count > 0)
    {
      await PublishEvents(events, cancellationToken).ConfigureAwait(false);

      await MarkEventsAsPublished(events, cancellationToken).ConfigureAwait(false);
    }
  }

  /// <inheritdoc/>
  public async Task<AppCommandResultWithoutValue> Save(
    AppOutboxSaveCommand command,
    CancellationToken cancellationToken)
  {
    List<AppEventPayloadWithDataAsDictionary> payloads = [];

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      var eventSaveTask = _appOutgoingEventCommandService.Save(
        command.ToAppOutgoingEventSaveCommand(),
        cancellationToken);

      var eventSaveResult = await eventSaveTask.ConfigureAwait(false);

      eventSaveResult.Data.ThrowExceptionIfNotSuccess();

      payloads.AddRange(eventSaveResult.Payloads);

      long appOutgoingEventId = eventSaveResult.Data.Value.Id;

      foreach (var payload in command.Payloads)
      {
        var eventPayloadSaveTask = _appOutgoingEventPayloadCommandService.Save(
          payload.ToAppOutgoingEventPayloadSaveCommand(appOutgoingEventId),
          cancellationToken);

        var eventPayloadSaveResult = await eventPayloadSaveTask.ConfigureAwait(false);

        eventPayloadSaveResult.Data.ThrowExceptionIfNotSuccess();

        payloads.AddRange(eventPayloadSaveResult.Payloads);
      }
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    AppCommandResultWithoutValue result = new(Result.NoContent());

    result.Payloads.AddRange(payloads);

    return result;
  }

  private Task<List<AppOutgoingEventSingleDTO>> GetUnpublishedEvents(
    int maxCount,
    CancellationToken cancellationToken)
  {
    AppOutgoingEventUnpublishedListQuery query = new()
    {
      MaxCount = maxCount,
    };

    return _appOutgoingEventQueryService.GetUnpublishedList(query, cancellationToken);
  }

  private Task MarkEventsAsPublished(
    IEnumerable<AppOutgoingEventSingleDTO> events,
    CancellationToken cancellationToken)
  {
    AppOutgoingEventMarkAsPublishedCommand command = new(events.Select(x => x.Id), DateTimeOffset.Now);

    return _appOutgoingEventCommandService.MarkAsPublished(command, cancellationToken);
  }

  private async ValueTask PublishEvents(
    IEnumerable<AppOutgoingEventSingleDTO> events,
    CancellationToken cancellationToken)
  {
    var idsLookup = events.ToLookup(x => x.Name, x => x.Id);

    foreach (var ids in idsLookup)
    {
      MessageSending sending = new(ids.Key, string.Join(",", ids.AsEnumerable()));

      await _appMessageProducer.Publish(sending, cancellationToken).ConfigureAwait(false);
    }
  }
}

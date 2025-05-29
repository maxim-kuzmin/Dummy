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
    var ids = await GetUnpublishedAppOutgoingEventList(command.EventMaxCountToPublish, cancellationToken).ConfigureAwait(false);

    if (ids.Count > 0)
    {
      await PublishAppOutgoingEvents(ids, cancellationToken).ConfigureAwait(false);

      await MarkAppOutgoingEventsAsPublished(ids, cancellationToken).ConfigureAwait(false);
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
      var taskForAppOutgoingEvent = _appOutgoingEventCommandService.Save(
        command.ToAppOutgoingEventSaveCommand(),
        cancellationToken);

      var resultForAppOutgoingEvent = await taskForAppOutgoingEvent.ConfigureAwait(false);

      resultForAppOutgoingEvent.Data.ThrowExceptionIfNotSuccess();

      payloads.AddRange(resultForAppOutgoingEvent.Payloads);

      long appOutgoingEventId = resultForAppOutgoingEvent.Data.Value.Id;

      foreach (var payload in command.Payloads)
      {
        var taskForAppOutgoingEventPayload = _appOutgoingEventPayloadCommandService.Save(
          payload.ToAppOutgoingEventPayloadSaveCommand(appOutgoingEventId),
          cancellationToken);

        var resultForAppOutgoingEventPayload = await taskForAppOutgoingEventPayload.ConfigureAwait(false);

        resultForAppOutgoingEventPayload.Data.ThrowExceptionIfNotSuccess();

        payloads.AddRange(resultForAppOutgoingEventPayload.Payloads);
      }
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    AppCommandResultWithoutValue result = new(Result.NoContent());

    result.Payloads.AddRange(payloads);

    return result;
  }

  private Task<List<long>> GetUnpublishedAppOutgoingEventList(int maxCount, CancellationToken cancellationToken)
  {
    AppOutgoingEventUnpublishedListQuery query = new()
    {
      MaxCount = maxCount,
    };

    return _appOutgoingEventQueryService.GetUnpublishedIdList(query, cancellationToken);
  }

  private Task MarkAppOutgoingEventsAsPublished(IEnumerable<long> ids, CancellationToken cancellationToken)
  {
    AppOutgoingEventMarkAsPublishedCommand command = new(ids, DateTimeOffset.Now);

    return _appOutgoingEventCommandService.MarkAsPublished(command, cancellationToken);
  }

  private ValueTask PublishAppOutgoingEvents(IEnumerable<long> ids, CancellationToken cancellationToken)
  {
    MessageSending sending = new(AppEventNameEnum.DummyItemChanged.ToString(), string.Join(",", ids));

    return _appMessageProducer.Publish(sending, cancellationToken);
  }
}

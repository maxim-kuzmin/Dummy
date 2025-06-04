namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutbox.Services;

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
  public Task Clear(AppOutboxClearCommand command, CancellationToken cancellationToken)
  {
    DateTimeOffset? maxDate = null;

    if (command.PublishedEventsLifetimeInMinutes > 0)
    {
      maxDate = DateTimeOffset.Now.AddMinutes(-command.PublishedEventsLifetimeInMinutes);
    }

    AppOutgoingEventDeletePublishedCommand publishedEventsDeleteCommand = new(MaxDate: maxDate);

    return _appOutgoingEventCommandService.DeletePublished(publishedEventsDeleteCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task Produce(AppOutboxProduceCommand command, CancellationToken cancellationToken)
  {
    AppOutgoingEventUnpublishedListQuery unpublishedEventsQuery = new(
      Ids: null,
      MaxCount: command.EventMaxCountToPublish);

    var unpublishedEventsTask = _appOutgoingEventQueryService.GetUnpublishedList(
      unpublishedEventsQuery,
      cancellationToken);

    var unpublishedEvents = await unpublishedEventsTask.ConfigureAwait(false);

    if (unpublishedEvents.Count == 0)
    {
      return;
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      var idsLookup = unpublishedEvents.ToLookup(x => x.Name, x => x.Id);

      foreach (var ids in idsLookup)
      {
        MessageSending sending = new(ids.Key, string.Join(",", ids.AsEnumerable()));

        await _appMessageProducer.Publish(sending, cancellationToken).ConfigureAwait(false);
      }

      AppOutgoingEventMarkAsPublishedCommand eventMarkAsPublishedCommand = new(
        Ids: unpublishedEvents.Select(x => x.Id),
        PublishedAt: DateTimeOffset.Now);

      var eventMarkAsPublishedTask = _appOutgoingEventCommandService.MarkAsPublished(
        eventMarkAsPublishedCommand,
        cancellationToken);

      await eventMarkAsPublishedTask.ConfigureAwait(false);
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);
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
}

namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Services;

/// <summary>
/// Сервис входящих сообщений приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных.</param>
/// <param name="_appIncomingEventCommandService">Сервис команд входящего события приложения.</param>
/// <param name="_appIncomingEventQueryService">Сервис запросов входящего события приложения.</param>
/// <param name="_appIncomingEventPayloadCommandService">
/// Сервис команд полезной нагрузки входящего события приложения.
/// </param>
/// <param name="_logger">Логгер.</param>
/// <param name="_mediator">Медиатор.</param>
public class AppInboxCommandService(  
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventCommandService _appIncomingEventCommandService,
  IAppIncomingEventQueryService _appIncomingEventQueryService,
  IAppIncomingEventPayloadCommandService _appIncomingEventPayloadCommandService,
  ILogger<AppInboxCommandService> _logger,
  IMediator _mediator) : IAppInboxCommandService
{
  /// <summary>
  /// Потребить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  public Task<Result> Consume(AppInboxConsumeCommand command, CancellationToken cancellationToken)
  {
    string[] eventIds = command.Message.Contains(',')
      ? command.Message.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
      : [command.Message];

    return eventIds.Length > 0
      ? InsertAppIncomingEvents(eventIds, command.Sender, cancellationToken)
      : Task.FromResult(Result.Success());
  }

  /// <inheritdoc/>
  public async Task<Result> Load(AppInboxLoadCommand command, CancellationToken cancellationToken)
  {
    var taskToGetUnloadedEvents = GetUnloadedEvents(
      command.EventName,
      command.EventMaxCountToLoad,
      cancellationToken);

    var unloadedEvents = await taskToGetUnloadedEvents.ConfigureAwait(false);

    foreach (var unloadedEvent in unloadedEvents)
    {
      var taskToDownloadEventPayloads = DownloadEventPayloads(
        unloadedEvent,
        command.PayloadPageSize,
        command.TimeoutInMillisecondsToGetPayloads,
        cancellationToken);

      await taskToDownloadEventPayloads.ConfigureAwait(false);
    }

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<Result> Process(AppInboxProcessCommand command, CancellationToken cancellationToken)
  {
    await Task.Delay(0, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  private async Task DownloadEventPayloads(
    AppIncomingEventSingleDTO eventDTO,
    int payloadPageSize,
    int timeoutInMillisecondsToGetPayloads,
    CancellationToken cancellationToken)
  {
    while (eventDTO.PayloadTotalCount == 0 || eventDTO.PayloadCount < eventDTO.PayloadTotalCount)
    {
      async Task FuncToExecute(CancellationToken cancellationToken)
      {
        bool isLoaded = false;

        try
        {
          var taskToGetPage = _mediator.Send(
            eventDTO.ToAppOutgoingEventPayloadGetPageActionRequest(payloadPageSize),
            cancellationToken);

          var resultToGetPage = await taskToGetPage.ConfigureAwait(false);

          resultToGetPage.ThrowExceptionIfNotSuccess();

          var data = resultToGetPage.Value;

          var items = data.Items;

          await InsertIncomingEventPayloads(items, eventDTO.ObjectId, cancellationToken).ConfigureAwait(false);

          eventDTO.PayloadCount += items.Count;
          eventDTO.PayloadTotalCount = data.TotalCount;

          isLoaded = true;
        }
        catch (Exception ex)
        {
          eventDTO.LastLoadingError = ex.ToString();

          _logger.LogError(ex, "MAKC:AppInboxCommandService:DownloadEventPayloads failed");
        }

        await SaveIncomingEvent(eventDTO, DateTimeOffset.Now, isLoaded, cancellationToken).ConfigureAwait(false);
      }

      await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

      if (timeoutInMillisecondsToGetPayloads > 0)
      {
        await Task.Delay(timeoutInMillisecondsToGetPayloads, cancellationToken).ConfigureAwait(false);
      }
    }
  }

  private Task<Result> InsertIncomingEventPayloads(
    List<AppOutgoingEventPayloadSingleDTO> appOutgoingEventPayloads,
    string? appIncomingEventObjectId,
    CancellationToken cancellationToken)
  {
    Guard.Against.NullOrWhiteSpace(appIncomingEventObjectId);

    var command = appOutgoingEventPayloads.ToAppIncomingEventPayloadInsertListCommand(
      appIncomingEventObjectId);

    return _appIncomingEventPayloadCommandService.InsertList(
      command,
      cancellationToken);
  }

  private Task<AppCommandResultWithValue<AppIncomingEventSingleDTO>> SaveIncomingEvent(
    AppIncomingEventSingleDTO eventDTO,
    DateTimeOffset now,
    bool isLoaded,
    CancellationToken cancellationToken)
  {
    eventDTO.LastLoadingAt = now;

    if (isLoaded && eventDTO.PayloadCount == eventDTO.PayloadTotalCount)
    {
      eventDTO.LoadedAt = now;
    }

    var command = eventDTO.ToAppIncomingEventUpdateCommand();

    return _appIncomingEventCommandService.Save(command, cancellationToken);
  }

  private Task<List<AppIncomingEventSingleDTO>> GetUnloadedEvents(
    string eventName,
    int eventMaxCountToLoad,
    CancellationToken cancellationToken)
  {
    AppIncomingEventUnloadedListQuery query = new(eventName)
    {
      MaxCount = eventMaxCountToLoad,
    };

    return _appIncomingEventQueryService.GetUnloadedList(query, cancellationToken);
  }

  private Task<Result> InsertAppIncomingEvents(
    string[] eventIds,
    string eventName,
    CancellationToken cancellationToken)
  {
    var command = eventIds.ToAppIncomingEventInsertListCommand(eventName);

    return _appIncomingEventCommandService.InsertList(command, cancellationToken);
  }
}

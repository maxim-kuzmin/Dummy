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
/// <param name="_appIncomingEventPayloadQueryService">
/// Сервис запросов полезной нагрузки входящего события приложения.
/// </param>
/// <param name="_logger">Логгер.</param>
/// <param name="_mediator">Медиатор.</param>
public class AppInboxCommandService(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventCommandService _appIncomingEventCommandService,
  IAppIncomingEventQueryService _appIncomingEventQueryService,
  IAppIncomingEventPayloadCommandService _appIncomingEventPayloadCommandService,
  IAppIncomingEventPayloadQueryService _appIncomingEventPayloadQueryService,
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
    var eventsGetTask = GetUnloadedEvents(
      command.EventName,
      command.EventMaxCountToLoad,
      cancellationToken);

    var eventDTOs = await eventsGetTask.ConfigureAwait(false);

    foreach (var eventDTO in eventDTOs)
    {
      var eventPayloadsLoadTask = LoadEventPayloads(
        eventDTO,
        command.PayloadPageSize,
        command.TimeoutInMillisecondsToGetPayloads,
        cancellationToken);

      await eventPayloadsLoadTask.ConfigureAwait(false);
    }

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<Result> Process(AppInboxProcessCommand command, CancellationToken cancellationToken)
  {
    var eventsGetTask = GetUnprocessedEvents(
      command.EventName,
      command.EventMaxCountToProcess,
      cancellationToken);

    var eventDTOs = await eventsGetTask.ConfigureAwait(false);

    foreach (var eventDTO in eventDTOs)
    {
      await ProcessEventPayloads(eventDTO, cancellationToken).ConfigureAwait(false);
    }

    return Result.Success();
  }

  private Task<Result> InsertEventPayloads(
    List<AppOutgoingEventPayloadSingleDTO> appOutgoingEventPayloads,
    string? appIncomingEventObjectId,
    CancellationToken cancellationToken)
  {
    Guard.Against.NullOrWhiteSpace(appIncomingEventObjectId);

    var command = appOutgoingEventPayloads.ToAppIncomingEventPayloadInsertListCommand(
      appIncomingEventObjectId);

    return _appIncomingEventPayloadCommandService.InsertList(command, cancellationToken);
  }

  private async Task LoadEventPayloads(
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
          var eventPayloadGetPageTask = _mediator.Send(
            eventDTO.ToAppOutgoingEventPayloadGetPageActionRequest(payloadPageSize),
            cancellationToken);

          var eventPayloadGetPageResult = await eventPayloadGetPageTask.ConfigureAwait(false);

          eventPayloadGetPageResult.ThrowExceptionIfNotSuccess();

          var data = eventPayloadGetPageResult.Value;

          var items = data.Items;

          await InsertEventPayloads(items, eventDTO.ObjectId, cancellationToken).ConfigureAwait(false);

          eventDTO.PayloadCount += items.Count;
          eventDTO.PayloadTotalCount = data.TotalCount;

          isLoaded = true;
        }
        catch (Exception ex)
        {
          eventDTO.LastLoadingError = ex.ToString();

          _logger.LogError(ex, "MAKC:AppInboxCommandService:DownloadEventPayloads failed");
        }

        await SaveEvent(eventDTO, DateTimeOffset.Now, isLoaded, cancellationToken).ConfigureAwait(false);
      }

      await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

      if (timeoutInMillisecondsToGetPayloads > 0)
      {
        await Task.Delay(timeoutInMillisecondsToGetPayloads, cancellationToken).ConfigureAwait(false);
      }
    }
  }

  private async Task ProcessEventPayloads(AppIncomingEventSingleDTO eventDTO, CancellationToken cancellationToken)
  {
    string appIncomingEventObjectId = Guard.Against.NullOrWhiteSpace(eventDTO.ObjectId);

    AppIncomingEventPayloadListQuery query = new(
      MaxCount: 0,
      Filter: new(FullTextSearchQuery: null, AppIncomingEventObjectId: appIncomingEventObjectId),
      Sort: new(Field: AppIncomingEventPayloadSettings.SortFieldForPosition, IsDesc: false));

    var eventPayloadsGetListTask = _appIncomingEventPayloadQueryService.GetList(query, cancellationToken);

    var eventPayloadDTOs = await eventPayloadsGetListTask.ConfigureAwait(false);

    foreach (var eventPayloadDTO in eventPayloadDTOs)
    {
      if (eventPayloadDTO.EntityName != "DummyItem")
      {
        throw new NotImplementedException();
      }

      bool isUnknownAction = eventPayloadDTO.EntityConcurrencyTokenToDelete == null
        && eventPayloadDTO.EntityConcurrencyTokenToInsert == null;

      if (isUnknownAction)
      {
        throw new Exception("Unknown action");
      }

      bool isProcessed = await ProcessEventPayload(eventPayloadDTO, cancellationToken).ConfigureAwait(false);

      if (!isProcessed)
      {
        break;
      }
    }
  }

  private async Task<bool> ProcessEventPayload(
    AppIncomingEventPayloadSingleDTO eventPayloadDTO,
    CancellationToken cancellationToken)
  {
    await Task.Delay(0, cancellationToken).ConfigureAwait(false);

    bool result = false;

    if (eventPayloadDTO.EntityConcurrencyTokenToDelete == null)
    {
      //вставляем
    }
    else if (eventPayloadDTO.EntityConcurrencyTokenToInsert == null)
    {
      //удаляем
    }
    else
    {
      //изменяем
    }

    return result;
  }

  private Task<AppCommandResultWithValue<AppIncomingEventSingleDTO>> SaveEvent(
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
    int maxCount,
    CancellationToken cancellationToken)
  {
    AppIncomingEventNamedListQuery query = new(eventName)
    {
      MaxCount = maxCount,
    };

    return _appIncomingEventQueryService.GetUnloadedList(query, cancellationToken);
  }

  private Task<List<AppIncomingEventSingleDTO>> GetUnprocessedEvents(
    string eventName,
    int maxCount,
    CancellationToken cancellationToken)
  {
    AppIncomingEventNamedListQuery query = new(eventName)
    {
      MaxCount = maxCount,
    };

    return _appIncomingEventQueryService.GetUnprocessedList(query, cancellationToken);
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

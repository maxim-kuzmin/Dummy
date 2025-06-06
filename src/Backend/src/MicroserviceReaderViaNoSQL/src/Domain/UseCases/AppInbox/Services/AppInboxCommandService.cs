﻿namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppInbox.Services;

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
/// <param name="_dummyItemCommandService">Сервис команд фиктивного предмета.</param>
/// <param name="_dummyItemQueryService">Сервис запросов фиктивного предмета.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_mediator">Медиатор.</param>
public class AppInboxCommandService(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventCommandService _appIncomingEventCommandService,
  IAppIncomingEventQueryService _appIncomingEventQueryService,
  IAppIncomingEventPayloadCommandService _appIncomingEventPayloadCommandService,
  IAppIncomingEventPayloadQueryService _appIncomingEventPayloadQueryService,
  IDummyItemCommandService _dummyItemCommandService,
  IDummyItemQueryService _dummyItemQueryService,
  ILogger<AppInboxCommandService> _logger,
  IMediator _mediator) : IAppInboxCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Clear(AppInboxClearCommand command, CancellationToken cancellationToken)
  {
    DateTimeOffset? maxDate = null;

    if (command.ProcessedEventsLifetimeInMinutes > 0)
    {
      maxDate = DateTimeOffset.Now.AddMinutes(-command.ProcessedEventsLifetimeInMinutes);
    }

    AppIncomingEventProcessedListQuery processedEventListQuery = new(
      MaxCount: command.EventMaxCountToClear,
      MaxDate: maxDate);

    int count = 0;

    do
    {
      var processedEventObjectIdsGetTask = _appIncomingEventQueryService.GetProcessedObjectIds(
        processedEventListQuery,
        cancellationToken);

      var processedEventObjectIds = await processedEventObjectIdsGetTask.ConfigureAwait(false);

      count = processedEventObjectIds.Count;

      if (count > 0)
      {
        async Task FuncToExecute(CancellationToken cancellationToken)
        {
          AppIncomingEventDeleteListCommand eventsDeleteCommand = new(ObjectIds: processedEventObjectIds);

          var eventsDeleteTask = _appIncomingEventCommandService.DeleteList(eventsDeleteCommand, cancellationToken);

          await eventsDeleteTask.ConfigureAwait(false);

          AppIncomingEventPayloadDeleteListCommand eventPayloadsDeleteCommand = new(
            ObjectIds: null,
            AppIncomingEventObjectIds: processedEventObjectIds);

          var eventPayloadsDeleteTask = _appIncomingEventPayloadCommandService.DeleteList(
            eventPayloadsDeleteCommand,
            cancellationToken);

          await eventPayloadsDeleteTask.ConfigureAwait(false);
        }

        await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);
      }

      if (command.TimeoutInMillisecondsToGetEvents > 0)
      {
        await Task.Delay(command.TimeoutInMillisecondsToGetEvents, cancellationToken).ConfigureAwait(false);
      }
    }
    while (count > 0 && !cancellationToken.IsCancellationRequested);

    return Result.Success();
  }

  /// <inheritdoc/>
  public Task<Result> Consume(AppInboxConsumeCommand command, CancellationToken cancellationToken)
  {
    string[] eventIds = command.Message.Contains(',')
      ? command.Message.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
      : [command.Message];

    return eventIds.Length > 0
      ? _appIncomingEventCommandService.InsertList(
        eventIds.ToAppIncomingEventInsertListCommand(command.Sender),
        cancellationToken)
      : Task.FromResult(Result.Success());
  }

  /// <inheritdoc/>
  public async Task<Result> Load(AppInboxLoadCommand command, CancellationToken cancellationToken)
  {
    AppIncomingEventNamedListQuery query = new(
      EventName: command.EventName,
      MaxCount: command.EventMaxCountToLoad);

    var eventsGetTask = _appIncomingEventQueryService.GetUnloadedList(query, cancellationToken);

    var eventDTOs = await eventsGetTask.ConfigureAwait(false);

    foreach (var eventDTO in eventDTOs)
    {
      var eventPayloadsLoadTask = LoadEventPayloads(
        eventDTO,
        command.PayloadPageSize,
        command.TimeoutInMillisecondsToGetEventPayloads,
        cancellationToken);

      await eventPayloadsLoadTask.ConfigureAwait(false);
    }

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<Result> Process(AppInboxProcessCommand command, CancellationToken cancellationToken)
  {
    AppIncomingEventNamedListQuery query = new(
      EventName: command.EventName,
      MaxCount: command.EventMaxCountToProcess);

    var eventsGetTask = _appIncomingEventQueryService.GetUnprocessedList(query, cancellationToken);

    var eventDTOs = await eventsGetTask.ConfigureAwait(false);

    foreach (var eventDTO in eventDTOs)
    {
      await ProcessEventPayloads(eventDTO, cancellationToken).ConfigureAwait(false);
    }

    return Result.Success();
  }

  private async Task LoadEventPayloads(
    AppIncomingEventSingleDTO eventDTO,
    int payloadPageSize,
    int timeoutInMillisecondsToGetEventPayloads,
    CancellationToken cancellationToken)
  {
    while (eventDTO.PayloadTotalCount == 0 || eventDTO.PayloadCount < eventDTO.PayloadTotalCount)
    {
      long payloadTotalCount = 0;

      async Task FuncToExecute(CancellationToken cancellationToken)
      {
        eventDTO.LastLoadingError = null;

        try
        {
          var eventPayloadGetPageTask = _mediator.Send(
            eventDTO.ToAppOutgoingEventPayloadGetPageActionRequest(payloadPageSize),
            cancellationToken);

          var eventPayloadGetPageResult = await eventPayloadGetPageTask.ConfigureAwait(false);

          eventPayloadGetPageResult.ThrowExceptionIfNotSuccess();

          var data = eventPayloadGetPageResult.Value;

          payloadTotalCount = data.TotalCount;

          var items = data.Items;

          if (items.Count > 0)
          {
            Guard.Against.NullOrWhiteSpace(eventDTO.ObjectId);

            var eventPayloadsInsertCommand = items.ToAppIncomingEventPayloadInsertListCommand(eventDTO.ObjectId);

            var eventPayloadsInsertTask = _appIncomingEventPayloadCommandService.InsertList(
              eventPayloadsInsertCommand,
              cancellationToken);

            await eventPayloadsInsertTask.ConfigureAwait(false);

            eventDTO.PayloadCount += items.Count;
            eventDTO.PayloadTotalCount = payloadTotalCount;
          }
        }
        catch (Exception ex)
        {
          eventDTO.LastLoadingError = ex.ToString();

          _logger.LogError(ex, "MAKC:AppInboxCommandService:DownloadEventPayloads failed");
        }

        var now = DateTimeOffset.Now;

        eventDTO.LastLoadingAt = now;

        if (eventDTO.LastLoadingError == null && eventDTO.PayloadCount == eventDTO.PayloadTotalCount)
        {
          eventDTO.LoadedAt = now;
        }

        var eventSaveTask = _appIncomingEventCommandService.Save(
          eventDTO.ToAppIncomingEventUpdateCommand(),
          cancellationToken);

        await eventSaveTask.ConfigureAwait(false);
      }

      await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

      if (payloadTotalCount == 0)
      {
        break;
      }

      if (timeoutInMillisecondsToGetEventPayloads > 0)
      {
        await Task.Delay(timeoutInMillisecondsToGetEventPayloads, cancellationToken).ConfigureAwait(false);
      }
    }
  }

  private async Task ProcessEventPayloads(AppIncomingEventSingleDTO eventDTO, CancellationToken cancellationToken)
  {
    string appIncomingEventObjectId = Guard.Against.NullOrWhiteSpace(eventDTO.ObjectId);

    bool isProcessed = eventDTO.PayloadTotalCount == 0;

    List<AppIncomingEventPayloadSingleDTO>? eventPayloadDTOs = null;

    if (!isProcessed)
    {
      AppIncomingEventPayloadListQuery query = new(
        MaxCount: 0,
        Filter: new(FullTextSearchQuery: null, AppIncomingEventObjectId: appIncomingEventObjectId),
        Sort: new(Field: AppIncomingEventPayloadSettings.SortFieldForPosition, IsDesc: false));

      var eventPayloadsGetListTask = _appIncomingEventPayloadQueryService.GetList(query, cancellationToken);

      eventPayloadDTOs = await eventPayloadsGetListTask.ConfigureAwait(false);
    }

    bool isTransactionCancelled = false;

    try
    {
      async Task FuncToExecute(CancellationToken cancellationToken)
      {
        if (eventPayloadDTOs != null)
        {
          foreach (var eventPayloadDTO in eventPayloadDTOs)
          {
            var eventPayloadProcessTask = ProcessEventPayload(eventPayloadDTO, eventDTO, cancellationToken);

            isProcessed = await eventPayloadProcessTask.ConfigureAwait(false);

            if (!isProcessed)
            {
              break;
            }
          }
        }

        var now = DateTimeOffset.Now;

        eventDTO.LastProcessingAt = now;

        if (isProcessed)
        {
          eventDTO.ProcessedAt = now;

          var eventSaveTask = _appIncomingEventCommandService.Save(
            eventDTO.ToAppIncomingEventUpdateCommand(),
            cancellationToken);

          await eventSaveTask.ConfigureAwait(false);
        }
        else
        {
          isTransactionCancelled = true;

          throw new Exception();
        }
      }

      await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);
    }
    catch
    {
      if (isTransactionCancelled)
      {
        var eventSaveTask = _appIncomingEventCommandService.Save(
          eventDTO.ToAppIncomingEventUpdateCommand(),
          cancellationToken);

        await eventSaveTask.ConfigureAwait(false);
      }
      else
      {
        throw;
      }
    }
  }

  private async Task<bool> ProcessEventPayload(
    AppIncomingEventPayloadSingleDTO eventPayloadDTO,
    AppIncomingEventSingleDTO eventDTO,
    CancellationToken cancellationToken)
  {
    eventDTO.LastProcessingError = null;

    try
    {
      if (eventPayloadDTO.EntityName != "DummyItem")
      {
        throw new Exception($"The event payload {eventPayloadDTO.ObjectId} entity name {eventPayloadDTO.EntityName} is unknown");
      }

      var eventAction = eventPayloadDTO.GetEventAction();

      if (eventAction == AppEventActionEnum.Unknown)
      {
        throw new Exception($"The event payload {eventPayloadDTO.ObjectId} action is unknown ");
      }

      long entityId = long.Parse(eventPayloadDTO.EntityId);

      DummyItemSingleQuery query = new(ObjectId: null, Id: entityId);

      var entityDTO = await _dummyItemQueryService.GetSingle(query, cancellationToken).ConfigureAwait(false);

      switch (eventAction)
      {
        case AppEventActionEnum.Delete:
          {
            if (entityDTO == null || entityDTO.ConcurrencyToken != eventPayloadDTO.EntityConcurrencyTokenToDelete)
            {
              return false;
            }

            DummyItemDeleteCommand command = new(ObjectId: entityDTO.ObjectId!);

            await _dummyItemCommandService.Delete(command, cancellationToken).ConfigureAwait(false);
          }
          break;
        case AppEventActionEnum.Insert:
          {
            if (entityDTO != null)
            {
              return entityDTO.ConcurrencyToken == eventPayloadDTO.EntityConcurrencyTokenToInsert;
            }

            var data = CreateDataToSave(eventPayloadDTO, entityDTO, entityId);

            if (data == null)
            {
              return false;
            }

            DummyItemSaveCommand command = new(IsUpdate: false, ObjectId: null, Data: data);

            await _dummyItemCommandService.Save(command, cancellationToken).ConfigureAwait(false);
          }
          break;
        case AppEventActionEnum.Update:
          {
            if (entityDTO == null || entityDTO.ConcurrencyToken != eventPayloadDTO.EntityConcurrencyTokenToDelete)
            {
              return false;
            }

            var data = CreateDataToSave(eventPayloadDTO, entityDTO, entityId);

            if (data == null)
            {
              return false;
            }

            DummyItemSaveCommand command = new(IsUpdate: true, ObjectId: entityDTO.ObjectId, Data: data);

            await _dummyItemCommandService.Save(command, cancellationToken).ConfigureAwait(false);
          }
          break;
        default:
          throw new NotImplementedException();
      }

      return true;
    }
    catch (Exception ex)
    {
      eventDTO.LastProcessingError = ex.ToString();

      return false;
    }
  }

  private static DummyItemCommandDataSection? CreateDataToSave(
    AppIncomingEventPayloadSingleDTO eventPayloadDTO,
    DummyItemSingleDTO? entityDTO,
    long entityId)
  {
    if (string.IsNullOrWhiteSpace(eventPayloadDTO.EntityConcurrencyTokenToInsert))
    {
      return null;
    }

    var data = eventPayloadDTO.Data.ToAppEventPayloadDataAsDictionary();

    if (data == null)
    {
      return null;
    }

    bool isNamePropertyFound = TryToFindNameProperty(data, out string name);

    if (entityDTO != null)
    {
      if (!isNamePropertyFound)
      {
        name = entityDTO.Name;
      }
    }
    else
    {
      if (!isNamePropertyFound)
      {
        return null;
      }
    }

    return new(
      Id: entityId,
      Name: name,
      ConcurrencyToken: eventPayloadDTO.EntityConcurrencyTokenToInsert);
  }

  private static bool TryToFindNameProperty(Dictionary<string, string?> data, out string value)
  {
    value = string.Empty;

    if (!data.TryGetValue("Name", out string? stringValue))
    {
      return false;
    }

    if (stringValue != null)
    {
      value = stringValue;
    }

    return true;
  }
}

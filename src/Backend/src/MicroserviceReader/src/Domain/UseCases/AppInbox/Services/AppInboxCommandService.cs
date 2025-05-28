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
/// <param name="_mediator">Медиатор.</param>
public class AppInboxCommandService(  
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventCommandService _appIncomingEventCommandService,
  IAppIncomingEventQueryService _appIncomingEventQueryService,
  IAppIncomingEventPayloadCommandService _appIncomingEventPayloadCommandService,
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
      : [];

    return eventIds.Length > 0
      ? InsertAppIncomingEvents(eventIds, command.Sender, cancellationToken)
      : Task.FromResult(Result.Success());
  }

  /// <inheritdoc/>
  public async Task<Result> Load(AppInboxLoadCommand command, CancellationToken cancellationToken)
  {
    var taskToGetUnloadedList = GetUnloadedAppIncomingEvents(command.EventName, command.MaxCount, cancellationToken);

    var unloadedList = await taskToGetUnloadedList.ConfigureAwait(false);

    foreach (var unloaded in unloadedList)
    {
      await DownloadEventPayloads(unloaded, 100, cancellationToken).ConfigureAwait(false);
    }

    return Result.Success();
  }

  private async Task DownloadEventPayloads(
    AppIncomingEventSingleDTO dto,
    int pageSize,
    CancellationToken cancellationToken)
  {
    string appIncomingEventObjectId = Guard.Against.NullOrWhiteSpace(dto.ObjectId);

    while (dto.PayloadTotalCount == 0 || dto.PayloadCount < dto.PayloadTotalCount)
    {
      async Task FuncToExecute(CancellationToken cancellationToken)
      {
        try
        {
          var taskToGetPage = _mediator.Send(
            dto.ToAppOutgoingEventPayloadGetPageActionRequest(pageSize),
            cancellationToken);

          var resultToGetPage = await taskToGetPage.ConfigureAwait(false);

          resultToGetPage.ThrowExceptionIfNotSuccess();

          var data = resultToGetPage.Value;

          var items = data.Items;

          dto.PayloadCount += items.Count;
          dto.PayloadTotalCount = data.TotalCount;

          await InsertEventPayloads(items, appIncomingEventObjectId, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
          dto.LastLoadingError = ex.ToString();
        }

        await SaveEvent(dto, appIncomingEventObjectId, DateTimeOffset.Now, cancellationToken).ConfigureAwait(false);
      }

      await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);
    }
  }

  private Task<Result> InsertEventPayloads(
    List<AppOutgoingEventPayloadSingleDTO> items,
    string appIncomingEventObjectId,
    CancellationToken cancellationToken)
  {
    AppIncomingEventPayloadInsertListCommand command = new(
      [.. items.Select(x => x.ToAppIncomingEventPayloadCommandDataSection(appIncomingEventObjectId))]);

    return _appIncomingEventPayloadCommandService.InsertList(
      command,
      cancellationToken);
  }

  private Task<AppCommandResultWithValue<AppIncomingEventSingleDTO>> SaveEvent(
    AppIncomingEventSingleDTO dto,
    string appIncomingEventObjectId,
    DateTimeOffset now,
    CancellationToken cancellationToken)
  {
    dto.LastLoadingAt = now;

    if (dto.PayloadCount == dto.PayloadTotalCount)
    {
      dto.LoadedAt = now;
    }

    AppIncomingEventSaveCommand command = new(
      IsUpdate: true,
      ObjectId: appIncomingEventObjectId,
      Data: new(
        EventId: dto.EventId,
        EventName: dto.EventName,
        LastLoadingAt: dto.LastLoadingAt,
        LastLoadingError: dto.LastLoadingError,
        LoadedAt: dto.LoadedAt,
        PayloadCount: dto.PayloadCount,
        PayloadTotalCount: dto.PayloadTotalCount,
        ProcessedAt: dto.ProcessedAt));

    return _appIncomingEventCommandService.Save(command, cancellationToken);
  }

  private Task<List<AppIncomingEventSingleDTO>> GetUnloadedAppIncomingEvents(
    string eventName,
    int maxCount,
    CancellationToken cancellationToken)
  {
    AppIncomingEventUnloadedListQuery query = new(eventName)
    {
      MaxCount = maxCount,
    };

    return _appIncomingEventQueryService.GetUnloadedList(query, cancellationToken);
  }

  private Task<Result> InsertAppIncomingEvents(
    string[] eventIds,
    string eventName,
    CancellationToken cancellationToken)
  {
    AppIncomingEventInsertListCommand command = new([..eventIds.Select(eventId =>
      new AppIncomingEventCommandDataSection(
        EventId: eventId,
        EventName: eventName,
        LastLoadingAt: null,
        LastLoadingError: null,
        LoadedAt: null,
        PayloadCount: 0,
        PayloadTotalCount: 0,
        ProcessedAt: null))]);

    return _appIncomingEventCommandService.InsertList(command, cancellationToken);
  }
}

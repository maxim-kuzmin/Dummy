namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppInbox.Services;

/// <summary>
/// Сервис входящих сообщений приложения.
/// </summary>
/// <param name="_appIncomingEventCommandService">Сервис команд входящего события приложения.</param>
/// <param name="_appIncomingEventQueryService">Сервис запросов входящего события приложения.</param>
/// <param name="_appIncomingEventPayloadQueryService">
/// Сервис запросов полезной нагрузки входящего события приложения.
/// </param>
public class AppInboxCommandService(
  IAppIncomingEventCommandService _appIncomingEventCommandService,
  IAppIncomingEventQueryService _appIncomingEventQueryService,
  IAppIncomingEventPayloadQueryService _appIncomingEventPayloadQueryService) : IAppInboxCommandService
{
  /// <summary>
  /// Потребить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  public Task<Result> Consume(AppInboxConsumeActionCommand command, CancellationToken cancellationToken)
  {
    string[] eventIds = command.Message.Contains(',')
      ? command.Message.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
      : [];

    return eventIds.Length > 0
      ? InsertAppIncomingEvents(eventIds, command.Sender, cancellationToken)
      : Task.FromResult(Result.Success());
  }

  /// <inheritdoc/>
  public async Task<Result> Load(AppInboxLoadActionCommand request, CancellationToken cancellationToken)
  {
    var taskToGetUnloadedList = GetUnloadedAppIncomingEvents(request.EventName, request.MaxCount, cancellationToken);

    var unloadedList = await taskToGetUnloadedList.ConfigureAwait(false);

    foreach (var unloaded in unloadedList)
    {
      await DownloadAppIncomingEventPayloads(unloaded.EventId, cancellationToken).ConfigureAwait(false);
    }

    return Result.Success();
  }

  private Task<AppIncomingEventPayloadListDTO> DownloadAppIncomingEventPayloads(
    string eventId,
    CancellationToken cancellationToken)
  {
    AppIncomingEventPayloadDownloadQuery query = new(eventId);

    return _appIncomingEventPayloadQueryService.Download(query, cancellationToken);
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
      new AppIncomingEventInsertSingleCommand(
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

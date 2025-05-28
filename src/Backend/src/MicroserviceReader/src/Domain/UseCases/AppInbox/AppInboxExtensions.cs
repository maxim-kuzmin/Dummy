namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox;

/// <summary>
/// Расширения входящих сообщений приложения.
/// </summary>
public static class AppInboxExtensions
{
  public static AppOutgoingEventPayloadGetPageActionRequest ToAppOutgoingEventPayloadGetPageActionRequest(
    this AppIncomingEventSingleDTO dto,
    int pageSize)
  {
    int pageNumber = dto.PayloadCount.ToPageNumber(pageSize);

    if (pageNumber > 1)
    {
      pageNumber++;
    }

    AppOutgoingEventPayloadPageQuery query = new(
      Page: new(Number: pageNumber, Size: pageSize),
      Sort: new(Field: AppOutgoingEventPayloadSettings.SortFieldForId, IsDesc: false),
      Filter: new(FullTextSearchQuery: null, AppOutgoingEventId: long.Parse(dto.EventId)));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к разделу данных команды полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <param name="appIncomingEventObjectId">Идентификатор объекта входящего события приложения.</param>
  /// <returns>Раздел данных команды полезной нагрузки входящего события приложения.</returns>
  public static AppIncomingEventPayloadCommandDataSection ToAppIncomingEventPayloadCommandDataSection(
    this AppOutgoingEventPayloadSingleDTO dto,
    string appIncomingEventObjectId
    )
  {
    AppEventPayloadWithDataAsString payload = new(dto.Data)
    {
      EntityId = dto.EntityId,
      EntityConcurrencyTokenToDelete = dto.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = dto.EntityConcurrencyTokenToInsert,
      EntityName = dto.EntityName,
      Position = dto.Position,
    };

    return new(
      AppIncomingEventObjectId: appIncomingEventObjectId,
      EventPayloadId: dto.Id.ToString(),
      Payload: payload);
  }

  /// <summary>
  /// Преобразовать к команде вставки списка полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="appOutgoingEventPayloads">Полезные нагрузки исходящего события.</param>
  /// <param name="appIncomingEventObjectId">Идентификатор объекта исходящего события.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventPayloadInsertListCommand ToAppIncomingEventPayloadInsertListCommand(
    this IEnumerable<AppOutgoingEventPayloadSingleDTO> appOutgoingEventPayloads,
    string appIncomingEventObjectId)
  {
    return new([..
      appOutgoingEventPayloads.Select(x => x.ToAppIncomingEventPayloadCommandDataSection(appIncomingEventObjectId))
      ]);
  }

  /// <summary>
  /// Преобразовать к команде вставки списка входящих событий приложения.
  /// </summary>
  /// <param name="eventIds">Идентификаторы событий.</param>
  /// <param name="eventName">Имя события.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventInsertListCommand ToAppIncomingEventInsertListCommand(
    this IEnumerable<string> eventIds,
    string eventName)
  {
    return new([..eventIds.Select(eventId =>
      new AppIncomingEventCommandDataSection(
        EventId: eventId,
        EventName: eventName,
        LastLoadingAt: null,
        LastLoadingError: null,
        LoadedAt: null,
        PayloadCount: 0,
        PayloadTotalCount: 0,
        ProcessedAt: null))]);
  }

  /// <summary>
  /// Преобразовать к команде обновления входящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventSaveCommand ToAppIncomingEventUpdateCommand(this AppIncomingEventSingleDTO dto)
  {
    return new(
      IsUpdate: true,
      ObjectId: dto.ObjectId,
      Data: new(
        EventId: dto.EventId,
        EventName: dto.EventName,
        LastLoadingAt: dto.LastLoadingAt,
        LastLoadingError: dto.LastLoadingError,
        LoadedAt: dto.LoadedAt,
        PayloadCount: dto.PayloadCount,
        PayloadTotalCount: dto.PayloadTotalCount,
        ProcessedAt: dto.ProcessedAt));
  }
}

namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcServer.AppIncomingEvent;

/// <summary>
/// Расширения входящего события приложения.
/// </summary>
public static class AppIncomingEventExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventDeleteActionRequest ToAppIncomingEventDeleteActionRequest(
    this AppIncomingEventDeleteGrpcRequest request)
  {
    AppIncomingEventDeleteCommand command = new(request.ObjectId);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventGetActionRequest ToAppIncomingEventGetActionRequest(
    this AppIncomingEventGetGrpcRequest request)
  {
    AppIncomingEventSingleQuery query = new(request.ObjectId);

    return new(query);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения входящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppIncomingEventGetGrpcReply ToAppIncomingEventGetGrpcReply(this AppIncomingEventSingleDTO dto)
  {
    return new()
    {
      ObjectId = dto.ObjectId,
      ConcurrencyToken = dto.ConcurrencyToken,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      EventId = dto.EventId,
      EventName = dto.EventName,
      LastLoadingAt = Timestamp.FromDateTimeOffset(dto.LastLoadingAt ?? default),
      LastLoadingError = dto.LastLoadingError,
      LoadedAt = Timestamp.FromDateTimeOffset(dto.LoadedAt ?? default),
      PayloadCount = dto.PayloadCount,
      PayloadTotalCount = dto.PayloadTotalCount,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка входящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventGetListActionRequest ToAppIncomingEventGetListActionRequest(
    this AppIncomingEventGetListGrpcRequest request)
  {
    AppIncomingEventPageQuery query = new(
      Page: new(request.Page.Number, request.Page.Size),
      Sort: new(request.Sort.Field, request.Sort.IsDesc),
      Filter: new(request.Filter.FullTextSearchQuery));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения списка входящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppIncomingEventGetListGrpcReply ToAppIncomingEventGetListGrpcReply(this AppIncomingEventPageDTO dto)
  {
    AppIncomingEventGetListGrpcReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      if (itemDTO == null)
      {
        continue;
      }

      var item = itemDTO.ToAppIncomingEventGetListGrpcReplyItem();

      result.Items.Add(item);
    }

    return result;
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventSaveActionRequest ToAppIncomingEventSaveActionRequest(
    this AppIncomingEventCreateGrpcRequest request)
  {
    var lastLoadingAt = request.LastLoadingAt.ToDateTimeOffset();
    var loadedAt = request.LoadedAt.ToDateTimeOffset();
    var processedAt = request.ProcessedAt.ToDateTimeOffset();

    AppIncomingEventSaveCommand command = new(
      IsUpdate: false,
      ObjectId: string.Empty,
      Data: new(
        EventId: request.EventId,
        EventName: request.EventName,
        LastLoadingAt: lastLoadingAt == default ? null : lastLoadingAt,
        LastLoadingError:request.LastLoadingError,
        LoadedAt: loadedAt == default ? null : loadedAt,
        PayloadCount: request.PayloadCount,
        PayloadTotalCount: request.PayloadTotalCount,
        ProcessedAt: processedAt == default ? null : processedAt));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventSaveActionRequest ToAppIncomingEventSaveActionRequest(
    this AppIncomingEventUpdateGrpcRequest request)
  {
    var lastLoadingAt = request.LastLoadingAt.ToDateTimeOffset();
    var loadedAt = request.LoadedAt.ToDateTimeOffset();
    var processedAt = request.ProcessedAt.ToDateTimeOffset();

    AppIncomingEventSaveCommand command = new(
      IsUpdate: true,
      ObjectId: request.ObjectId,
      Data: new(
        EventId: request.EventId,
        EventName: request.EventName,
        LastLoadingAt: lastLoadingAt == default ? null : lastLoadingAt,
        LastLoadingError: request.LastLoadingError,
        LoadedAt: loadedAt == default ? null : loadedAt,
        PayloadCount: request.PayloadCount,
        PayloadTotalCount: request.PayloadTotalCount,
        ProcessedAt: processedAt == default ? null : processedAt));

    return new(command);
  }

  private static AppIncomingEventGetListGrpcReplyItem ToAppIncomingEventGetListGrpcReplyItem(
    this AppIncomingEventSingleDTO dto)
  {
    return new()
    {
      ObjectId = dto.ObjectId,
      ConcurrencyToken = dto.ConcurrencyToken,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      EventId = dto.EventId,
      EventName = dto.EventName,
      LastLoadingAt = Timestamp.FromDateTimeOffset(dto.LastLoadingAt ?? default),
      LastLoadingError = dto.LastLoadingError,
      LoadedAt = Timestamp.FromDateTimeOffset(dto.LoadedAt ?? default),
      PayloadCount = dto.PayloadCount,
      PayloadTotalCount = dto.PayloadTotalCount,
    };
  }
}

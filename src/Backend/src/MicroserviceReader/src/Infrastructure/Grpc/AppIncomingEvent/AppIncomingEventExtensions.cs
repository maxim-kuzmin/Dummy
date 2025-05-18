namespace Makc.Dummy.MicroserviceReader.Infrastructure.Grpc.AppIncomingEvent;

/// <summary>
/// Расширения входящего события приложения.
/// </summary>
public static class AppIncomingEventExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по удалению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventDeleteActionCommand ToAppIncomingEventDeleteActionCommand(
    this AppIncomingEventDeleteGrpcRequest request)
  {
    return new(request.ObjectId);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static AppIncomingEventGetActionQuery ToAppIncomingEventGetActionQuery(this AppIncomingEventGetGrpcRequest request)
  {
    return new(request.ObjectId);
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
  /// <returns>Запрос.</returns>
  public static AppIncomingEventGetListActionQuery ToAppIncomingEventGetListActionQuery(
    this AppIncomingEventGetListGrpcRequest request)
  {
    AppIncomingEventPageQuery pageQuery = new()
    {
      Page = new(request.Page.Number, request.Page.Size),
      Filter = new(request.Filter.FullTextSearchQuery)
    };

    return new(pageQuery)
    {
      Sort = new(request.Sort.Field, request.Sort.IsDesc)
    };
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения списка входящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppIncomingEventGetListGrpcReply ToAppIncomingEventGetListGrpcReply(this AppIncomingEventListDTO dto)
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
  /// Преобразовать к команде действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns
  public static AppIncomingEventSaveActionCommand ToAppIncomingEventSaveActionCommand(
    this AppIncomingEventCreateGrpcRequest request)
  {
    var lastLoadingAt = request.LastLoadingAt.ToDateTimeOffset();
    var loadedAt = request.LoadedAt.ToDateTimeOffset();
    var processedAt = request.ProcessedAt.ToDateTimeOffset();

    return new(
      false,
      string.Empty,
      request.EventId,
      request.EventName,
      lastLoadingAt == default ? null : lastLoadingAt,
      request.LastLoadingError,
      loadedAt == default ? null : loadedAt,
      request.PayloadCount,
      request.PayloadTotalCount,
      processedAt == default ? null : processedAt);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns
  public static AppIncomingEventSaveActionCommand ToAppIncomingEventSaveActionCommand(
    this AppIncomingEventUpdateGrpcRequest request)
  {
    var lastLoadingAt = request.LastLoadingAt.ToDateTimeOffset();
    var loadedAt = request.LoadedAt.ToDateTimeOffset();
    var processedAt = request.ProcessedAt.ToDateTimeOffset();

    return new(
      true,
      request.ObjectId,
      request.EventId,
      request.EventName,
      lastLoadingAt == default ? null : lastLoadingAt,
      request.LastLoadingError,
      loadedAt == default ? null : loadedAt,
      request.PayloadCount,
      request.PayloadTotalCount,
      processedAt == default ? null : processedAt);
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

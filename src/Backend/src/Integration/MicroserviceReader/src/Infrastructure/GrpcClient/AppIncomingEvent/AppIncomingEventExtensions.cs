namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.AppIncomingEvent;

/// <summary>
/// Расширения входящего события приложения.
/// </summary>
public static class AppIncomingEventExtensions
{
  /// <summary>
  /// Преобразовать к запросу gRPC создания входящего события приложения.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventCreateGrpcRequest ToAppIncomingEventCreateGrpcRequest(
    this AppIncomingEventCommandDataSection data)
  {
    return new AppIncomingEventCreateGrpcRequest
    {
      EventId = data.EventId,
      EventName = data.EventName,
      LastLoadingAt = Timestamp.FromDateTimeOffset(data.LastLoadingAt ?? default),
      LastLoadingError = data.LastLoadingError,
      LoadedAt = Timestamp.FromDateTimeOffset(data.LoadedAt ?? default),
      PayloadCount = data.PayloadCount,
      PayloadTotalCount = data.PayloadTotalCount,
      ProcessedAt = Timestamp.FromDateTimeOffset(data.ProcessedAt ?? default)
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC удаления входящего события приложения.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventDeleteGrpcRequest ToAppIncomingEventDeleteGrpcRequest(
    this AppIncomingEventDeleteCommand command)
  {
    return new AppIncomingEventDeleteGrpcRequest
    {
      ObjectId = command.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения входящего события приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventGetGrpcRequest ToAppIncomingEventGetGrpcRequest(this AppIncomingEventSingleQuery query)
  {
    return new AppIncomingEventGetGrpcRequest
    {
      ObjectId = query.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения списка входящих событий приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventGetListGrpcRequest ToAppIncomingEventGetListGrpcRequest(this AppIncomingEventPageQuery query)
  {
    var filter = query.Filter;
    var page = query.Page;
    var sort = query.Sort;

    return new()
    {
      Page = new()
      {
        Number = page?.Number ?? 0,
        Size = page?.Size ?? 0
      },
      Sort = new()
      {
        Field = sort?.Field ?? string.Empty,
        IsDesc = sort?.IsDesc ?? false,
      },
      Filter = new()
      {
        FullTextSearchQuery = filter?.FullTextSearchQuery ?? string.Empty,
      }
    };
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных страницы входящих событий приложения.
  /// </summary>
  /// <param name="listReply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppIncomingEventPageDTO ToAppIncomingEventPageDTO(this AppIncomingEventGetListGrpcReply listReply)
  {
    var items = new List<AppIncomingEventSingleDTO>(listReply.Items.Count);

    foreach (var reply in listReply.Items)
    {
      var lastLoadingAt = reply.LastLoadingAt.ToDateTimeOffset();
      var loadedAt = reply.LoadedAt.ToDateTimeOffset();
      var processedAt = reply.ProcessedAt.ToDateTimeOffset();

      AppIncomingEventSingleDTO item = new()
      {
        ObjectId = reply.ObjectId,
        ConcurrencyToken = reply.ConcurrencyToken,
        CreatedAt = reply.CreatedAt.ToDateTimeOffset(),
        EventId = reply.EventId,
        EventName = reply.EventName,
        LastLoadingAt = lastLoadingAt == default ? null : lastLoadingAt,
        LastLoadingError = reply.LastLoadingError,
        LoadedAt = loadedAt == default ? null : loadedAt,
        PayloadCount = reply.PayloadCount,
        PayloadTotalCount = reply.PayloadTotalCount,
        ProcessedAt = processedAt == default ? null : processedAt,
      };

      items.Add(item);
    }

    return new(items, listReply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных единственного входящего события приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppIncomingEventSingleDTO ToAppIncomingEventSingleDTO(this AppIncomingEventGetGrpcReply reply)
  {
    var lastLoadingAt = reply.LastLoadingAt.ToDateTimeOffset();
    var loadedAt = reply.LoadedAt.ToDateTimeOffset();
    var processedAt = reply.ProcessedAt.ToDateTimeOffset();

    return new()
    {
      ObjectId = reply.ObjectId,
      ConcurrencyToken = reply.ConcurrencyToken,
      CreatedAt = reply.CreatedAt.ToDateTimeOffset(),
      EventId = reply.EventId,
      EventName = reply.EventName,
      LastLoadingAt = lastLoadingAt == default ? null : lastLoadingAt,
      LastLoadingError = reply.LastLoadingError,
      LoadedAt = loadedAt == default ? null : loadedAt,
      PayloadCount = reply.PayloadCount,
      PayloadTotalCount = reply.PayloadTotalCount,
      ProcessedAt = processedAt == default ? null : processedAt,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC обновления входящего события приложения.
  /// </summary>
  /// <param name="data">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventUpdateGrpcRequest ToAppIncomingEventUpdateGrpcRequest(
    this AppIncomingEventCommandDataSection data,
    string objectId)
  {
    return new AppIncomingEventUpdateGrpcRequest
    {
      ObjectId = objectId,
      EventId = data.EventId,
      EventName = data.EventName,
      LastLoadingAt = Timestamp.FromDateTimeOffset(data.LastLoadingAt ?? default),
      LastLoadingError = data.LastLoadingError,
      LoadedAt = Timestamp.FromDateTimeOffset(data.LoadedAt ?? default),
      PayloadCount = data.PayloadCount,
      PayloadTotalCount = data.PayloadTotalCount,
      ProcessedAt = Timestamp.FromDateTimeOffset(data.ProcessedAt ?? default)
    };
  }
}

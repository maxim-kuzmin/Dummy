namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.AppIncomingEventPayload;

/// <summary>
/// Расширения полезной нагрузки входящего события приложения.
/// </summary>
public static class AppIncomingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к запросу gRPC создания полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventPayloadCreateGrpcRequest ToAppIncomingEventPayloadCreateGrpcRequest(
    this AppIncomingEventPayloadCommandDataSection data)
  {
    var payload = data.Payload;

    return new AppIncomingEventPayloadCreateGrpcRequest
    {
      AppIncomingEventObjectId = data.AppIncomingEventObjectId,
      Data = payload.Data,
      EntityConcurrencyTokenToDelete = payload.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = payload.EntityConcurrencyTokenToInsert,
      EntityId = payload.EntityId,
      EntityName = payload.EntityName,
      EventPayloadId = data.EventPayloadId,
      Position = payload.Position
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC удаления полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventPayloadDeleteGrpcRequest ToAppIncomingEventPayloadDeleteGrpcRequest(
    this AppIncomingEventPayloadDeleteCommand command)
  {
    return new AppIncomingEventPayloadDeleteGrpcRequest
    {
      ObjectId = command.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventPayloadGetGrpcRequest ToAppIncomingEventPayloadGetGrpcRequest(
    this AppIncomingEventPayloadSingleQuery query)
  {
    return new AppIncomingEventPayloadGetGrpcRequest
    {
      ObjectId = query.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения списка полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventPayloadGetListGrpcRequest ToAppIncomingEventPayloadGetListGrpcRequest(
    this AppIncomingEventPayloadPageQuery query)
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
  /// Преобразовать к объекту передачи данных страницы полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="listReply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppIncomingEventPayloadPageDTO ToAppIncomingEventPayloadPageDTO(
    this AppIncomingEventPayloadGetListGrpcReply listReply)
  {
    var items = new List<AppIncomingEventPayloadSingleDTO>(listReply.Items.Count);

    foreach (var reply in listReply.Items)
    {
      AppIncomingEventPayloadSingleDTO item = new(
        ObjectId: reply.ObjectId,
        CreatedAt: reply.CreatedAt.ToDateTimeOffset(),
        ConcurrencyToken: reply.ConcurrencyToken,
        AppIncomingEventObjectId: reply.AppIncomingEventObjectId,
        Data: reply.Data,
        EntityConcurrencyTokenToDelete: reply.EntityConcurrencyTokenToDelete,
        EntityConcurrencyTokenToInsert: reply.EntityConcurrencyTokenToInsert,
        EntityId: reply.EntityId,
        EntityName: reply.EntityName,
        EventPayloadId: reply.EventPayloadId,
        Position: reply.Position);

      items.Add(item);
    }

    return new(items, listReply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных единственного полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppIncomingEventPayloadSingleDTO ToAppIncomingEventPayloadSingleDTO(
    this AppIncomingEventPayloadGetGrpcReply reply)
  {
    return new(
      ObjectId: reply.ObjectId,
      CreatedAt: reply.CreatedAt.ToDateTimeOffset(),
      ConcurrencyToken: reply.ConcurrencyToken,
      AppIncomingEventObjectId: reply.AppIncomingEventObjectId,
      Data: reply.Data,
      EntityConcurrencyTokenToDelete: reply.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert: reply.EntityConcurrencyTokenToInsert,
      EntityId: reply.EntityId,
      EntityName: reply.EntityName,
      EventPayloadId: reply.EventPayloadId,
      Position: reply.Position);
  }

  /// <summary>
  /// Преобразовать к запросу gRPC обновления полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="data">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventPayloadUpdateGrpcRequest ToAppIncomingEventPayloadUpdateGrpcRequest(
    this AppIncomingEventPayloadCommandDataSection data,
    string objectId)
  {
    var payload = data.Payload;

    return new AppIncomingEventPayloadUpdateGrpcRequest
    {
      ObjectId = objectId,
      AppIncomingEventObjectId = data.AppIncomingEventObjectId,
      Data = payload.Data,
      EntityConcurrencyTokenToDelete = payload.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = payload.EntityConcurrencyTokenToInsert,
      EntityId = payload.EntityId,
      EntityName = payload.EntityName,
      EventPayloadId = data.EventPayloadId,
      Position = payload.Position
    };
  }
}

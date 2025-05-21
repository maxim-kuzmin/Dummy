namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.AppOutgoingEventPayload;

/// <summary>
/// Расширения полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к запросу gRPC создания полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventPayloadCreateGrpcRequest ToAppOutgoingEventPayloadCreateGrpcRequest(
    this AppOutgoingEventPayloadCommandDataSection data)
  {
    var payload = data.Payload;

    return new AppOutgoingEventPayloadCreateGrpcRequest
    {
      AppOutgoingEventId = data.AppOutgoingEventId,
      Data = payload.Data,
      EntityConcurrencyTokenToDelete = payload.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = payload.EntityConcurrencyTokenToInsert,
      EntityId = payload.EntityId,
      EntityName = payload.EntityName,
      Position = payload.Position
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC удаления полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventPayloadDeleteGrpcRequest ToAppOutgoingEventPayloadDeleteGrpcRequest(
    this AppOutgoingEventPayloadDeleteCommand command)
  {
    return new AppOutgoingEventPayloadDeleteGrpcRequest
    {
      Id = command.Id,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventPayloadGetGrpcRequest ToAppOutgoingEventPayloadGetGrpcRequest(
    this AppOutgoingEventPayloadSingleQuery query)
  {
    return new AppOutgoingEventPayloadGetGrpcRequest
    {
      Id = query.Id,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения списка полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventPayloadGetListGrpcRequest ToAppOutgoingEventPayloadGetListGrpcRequest(
    this AppOutgoingEventPayloadPageQuery query)
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
  /// Преобразовать к объекту передачи данных страницы полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="listReply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppOutgoingEventPayloadPageDTO ToAppOutgoingEventPayloadPageDTO(
    this AppOutgoingEventPayloadGetListGrpcReply listReply)
  {
    var items = new List<AppOutgoingEventPayloadSingleDTO>(listReply.Items.Count);

    foreach (var reply in listReply.Items)
    {
      AppOutgoingEventPayloadSingleDTO item = new(
        Id: reply.Id,
        ConcurrencyToken: reply.ConcurrencyToken,
        AppOutgoingEventId: reply.AppOutgoingEventId,
        Data: reply.Data,
        EntityConcurrencyTokenToDelete: reply.EntityConcurrencyTokenToDelete,
        EntityConcurrencyTokenToInsert: reply.EntityConcurrencyTokenToInsert,
        EntityId: reply.EntityId,
        EntityName: reply.EntityName,
        Position: reply.Position);

      items.Add(item);
    }

    return items.ToAppOutgoingEventPayloadPageDTO(listReply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных единственного полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppOutgoingEventPayloadSingleDTO ToAppOutgoingEventPayloadSingleDTO(
    this AppOutgoingEventPayloadGetGrpcReply reply)
  {
    return new(
      Id: reply.Id,
      ConcurrencyToken: reply.ConcurrencyToken,
      AppOutgoingEventId: reply.AppOutgoingEventId,
      Data: reply.Data,
      EntityConcurrencyTokenToDelete: reply.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert: reply.EntityConcurrencyTokenToInsert,
      EntityId: reply.EntityId,
      EntityName: reply.EntityName,
      Position: reply.Position);
  }

  /// <summary>
  /// Преобразовать к запросу gRPC обновления полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <param name="id">Идентификатор.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventPayloadUpdateGrpcRequest ToAppOutgoingEventPayloadUpdateGrpcRequest(
    this AppOutgoingEventPayloadCommandDataSection data,
    long id)
  {
    var payload = data.Payload;

    return new AppOutgoingEventPayloadUpdateGrpcRequest
    {
      Id = id,
      AppOutgoingEventId = data.AppOutgoingEventId,
      Data = payload.Data,
      EntityConcurrencyTokenToDelete = payload.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = payload.EntityConcurrencyTokenToInsert,
      EntityId = payload.EntityId,
      EntityName = payload.EntityName,
      Position = payload.Position
    };
  }
}

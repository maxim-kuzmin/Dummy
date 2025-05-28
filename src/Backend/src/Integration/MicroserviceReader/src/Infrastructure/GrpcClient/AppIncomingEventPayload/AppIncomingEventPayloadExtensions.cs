using Ardalis.GuardClauses;

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
    this AppIncomingEventPayloadListQuery query)
  {
    var sort = query.Sort;
    var filter = query.Filter;

    return new()
    {
      MaxCount = query.MaxCount,
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
  /// Преобразовать к запросу gRPC получения страницы полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventPayloadGetPageGrpcRequest ToAppIncomingEventPayloadGetPageGrpcRequest(
    this AppIncomingEventPayloadPageQuery query)
  {
    var page = query.Page;
    var sort = query.Sort;
    var filter = query.Filter;

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
  /// Преобразовать к списку полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Список полезных нагрузок входящего события приложения.</returns>
  public static List<AppIncomingEventPayloadSingleDTO> ToAppIncomingEventPayloadListDTO(
    this AppIncomingEventPayloadGetListGrpcReply reply)
  {
    return reply.Items.ToAppIncomingEventPayloadListDTO();
  }

  /// <summary>
  /// Преобразовать к странице полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Страница полезных нагрузок входящего события приложения.</returns>
  public static AppIncomingEventPayloadPageDTO ToAppIncomingEventPayloadPageDTO(
    this AppIncomingEventPayloadGetPageGrpcReply reply)
  {
    var items = reply.Items.ToAppIncomingEventPayloadListDTO();

    return items.ToAppIncomingEventPayloadPageDTO(reply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к полезной нагрузке входящего события приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Полезная нагрузка входящего события приложения.</returns>
  public static AppIncomingEventPayloadSingleDTO ToAppIncomingEventPayloadSingleDTO(
    this AppIncomingEventPayloadGetGrpcReply reply)
  {
    return new()
    {
      ObjectId = reply.ObjectId,
      CreatedAt = reply.CreatedAt.ToDateTimeOffset(),
      ConcurrencyToken = reply.ConcurrencyToken,
      AppIncomingEventObjectId = reply.AppIncomingEventObjectId,
      Data = reply.Data,
      EntityConcurrencyTokenToDelete = reply.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = reply.EntityConcurrencyTokenToInsert,
      EntityId = reply.EntityId,
      EntityName = reply.EntityName,
      EventPayloadId = reply.EventPayloadId,
      Position = reply.Position,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC обновления полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="data">Команда.</param>
  /// <param name="objectId">Идентификатор объекта.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventPayloadUpdateGrpcRequest ToAppIncomingEventPayloadUpdateGrpcRequest(
    this AppIncomingEventPayloadCommandDataSection data,
    string? objectId)
  {
    Guard.Against.NullOrWhiteSpace(objectId);

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

  private static List<AppIncomingEventPayloadSingleDTO> ToAppIncomingEventPayloadListDTO(
    this RepeatedField<AppIncomingEventPayloadGetListGrpcReplyItem> reply)
  {
    var result = new List<AppIncomingEventPayloadSingleDTO>(reply.Count);

    foreach (var item in reply)
    {
      result.Add(item.ToAppIncomingEventPayloadSingleDTO());
    }

    return result;
  }

  private static AppIncomingEventPayloadSingleDTO ToAppIncomingEventPayloadSingleDTO(
    this AppIncomingEventPayloadGetListGrpcReplyItem reply)
  {
    return new()
    {
      ObjectId = reply.ObjectId,
      CreatedAt = reply.CreatedAt.ToDateTimeOffset(),
      ConcurrencyToken = reply.ConcurrencyToken,
      AppIncomingEventObjectId = reply.AppIncomingEventObjectId,
      Data = reply.Data,
      EntityConcurrencyTokenToDelete = reply.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = reply.EntityConcurrencyTokenToInsert,
      EntityId = reply.EntityId,
      EntityName = reply.EntityName,
      EventPayloadId = reply.EventPayloadId,
      Position = reply.Position,
    };
  }
}

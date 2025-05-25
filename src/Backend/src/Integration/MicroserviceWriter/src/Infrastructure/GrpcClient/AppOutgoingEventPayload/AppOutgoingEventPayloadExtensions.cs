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
    this AppOutgoingEventPayloadListQuery query)
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
  /// Преобразовать к запросу gRPC получения страницы полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventPayloadGetPageGrpcRequest ToAppOutgoingEventPayloadGetPageGrpcRequest(
    this AppOutgoingEventPayloadPageQuery query)
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
  /// Преобразовать к списку полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Список.</returns>
  public static List<AppOutgoingEventPayloadSingleDTO> ToAppOutgoingEventPayloadListDTO(
    this AppOutgoingEventPayloadGetListGrpcReply reply)
  {
    return reply.Items.ToAppOutgoingEventPayloadListDTO();
  }

  /// <summary>
  /// Преобразовать к странице полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Страница.</returns>
  public static AppOutgoingEventPayloadPageDTO ToAppOutgoingEventPayloadPageDTO(
    this AppOutgoingEventPayloadGetPageGrpcReply reply)
  {
    var items = reply.Items.ToAppOutgoingEventPayloadListDTO();

    return items.ToAppOutgoingEventPayloadPageDTO(reply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к полезной нагрузке исходящего события приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Полезная нагрузка исходящего события приложения.</returns>
  public static AppOutgoingEventPayloadSingleDTO ToAppOutgoingEventPayloadSingleDTO(
    this AppOutgoingEventPayloadGetGrpcReply reply)
  {
    return new()
    {
      Id = reply.Id,
      ConcurrencyToken = reply.ConcurrencyToken,
      AppOutgoingEventId = reply.AppOutgoingEventId,
      Data = reply.Data,
      EntityConcurrencyTokenToDelete = reply.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = reply.EntityConcurrencyTokenToInsert,
      EntityId = reply.EntityId,
      EntityName = reply.EntityName,
      Position = reply.Position,
    };
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

  private static List<AppOutgoingEventPayloadSingleDTO> ToAppOutgoingEventPayloadListDTO(
    this RepeatedField<AppOutgoingEventPayloadGetListGrpcReplyItem> reply)
  {
    var result = new List<AppOutgoingEventPayloadSingleDTO>(reply.Count);

    foreach (var item in reply)
    {
      result.Add(item.ToAppOutgoingEventPayloadSingleDTO());
    }

    return result;
  }

  private static AppOutgoingEventPayloadSingleDTO ToAppOutgoingEventPayloadSingleDTO(
    this AppOutgoingEventPayloadGetListGrpcReplyItem reply)
  {
    return new()
    {
      Id = reply.Id,
      ConcurrencyToken = reply.ConcurrencyToken,
      AppOutgoingEventId = reply.AppOutgoingEventId,
      Data = reply.Data,
      EntityConcurrencyTokenToDelete = reply.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = reply.EntityConcurrencyTokenToInsert,
      EntityId = reply.EntityId,
      EntityName = reply.EntityName,
      Position = reply.Position,
    };
  }
}

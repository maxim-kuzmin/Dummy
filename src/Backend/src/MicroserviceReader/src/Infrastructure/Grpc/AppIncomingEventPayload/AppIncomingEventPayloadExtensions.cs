namespace Makc.Dummy.MicroserviceReader.Infrastructure.Grpc.AppIncomingEventPayload;

/// <summary>
/// Расширения полезной нагрузки входящего события приложения.
/// </summary>
public static class AppIncomingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по удалению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventPayloadDeleteActionCommand ToAppIncomingEventPayloadDeleteActionCommand(
    this AppIncomingEventPayloadDeleteGrpcRequest request)
  {
    return new(request.ObjectId);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static AppIncomingEventPayloadGetActionQuery ToAppIncomingEventPayloadGetActionQuery(
    this AppIncomingEventPayloadGetGrpcRequest request)
  {
    return new(request.ObjectId);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppIncomingEventPayloadGetGrpcReply ToAppIncomingEventPayloadGetGrpcReply(
    this AppIncomingEventPayloadSingleDTO dto)
  {
    return new()
    {
      ObjectId = dto.ObjectId,
      AppIncomingEventObjectId = dto.AppIncomingEventId,
      ConcurrencyToken = dto.ConcurrencyToken,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      Data = dto.Data,
      EntityConcurrencyTokenToDelete = dto.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = dto.EntityConcurrencyTokenToInsert,
      EntityId = dto.EntityId,
      EntityName = dto.EntityName,
      EventPayloadId = dto.EventPayloadId,
      Position = dto.Position,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static AppIncomingEventPayloadGetListActionQuery ToAppIncomingEventPayloadGetListActionQuery(
    this AppIncomingEventPayloadGetListGrpcRequest request)
  {
    AppIncomingEventPayloadPageQuery pageQuery = new()
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
  /// Преобразовать к отклику gRPC получения списка полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppIncomingEventPayloadGetListGrpcReply ToAppIncomingEventPayloadGetListGrpcReply(
    this AppIncomingEventPayloadListDTO dto)
  {
    AppIncomingEventPayloadGetListGrpcReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      if (itemDTO == null)
      {
        continue;
      }

      var item = itemDTO.ToAppIncomingEventPayloadGetListGrpcReplyItem();

      result.Items.Add(item);
    }

    return result;
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns
  public static AppIncomingEventPayloadSaveActionCommand ToAppIncomingEventPayloadSaveActionCommand(
    this AppIncomingEventPayloadCreateGrpcRequest request)
  {
    AppEventPayloadWithDataAsString payload = new(request.Data)
    {
      EntityConcurrencyTokenToDelete = request.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = request.EntityConcurrencyTokenToInsert,
      EntityId = request.EntityId,
      EntityName = request.EntityName,
      Position = request.Position,
    };

    return new(false, string.Empty, request.AppIncomingEventObjectId, payload);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns
  public static AppIncomingEventPayloadSaveActionCommand ToAppIncomingEventPayloadSaveActionCommand(
    this AppIncomingEventPayloadUpdateGrpcRequest request)
  {
    AppEventPayloadWithDataAsString payload = new(request.Data)
    {
      EntityConcurrencyTokenToDelete = request.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = request.EntityConcurrencyTokenToInsert,
      EntityId = request.EntityId,
      EntityName = request.EntityName,
      Position = request.Position,
    };

    return new(true, request.ObjectId, request.AppIncomingEventObjectId, payload);
  }

  private static AppIncomingEventPayloadGetListGrpcReplyItem ToAppIncomingEventPayloadGetListGrpcReplyItem(
    this AppIncomingEventPayloadSingleDTO dto)
  {
    return new()
    {
      ObjectId = dto.ObjectId,
      AppIncomingEventObjectId = dto.AppIncomingEventId,
      ConcurrencyToken = dto.ConcurrencyToken,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      Data = dto.Data,
      EntityConcurrencyTokenToDelete = dto.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = dto.EntityConcurrencyTokenToInsert,
      EntityId = dto.EntityId,
      EntityName = dto.EntityName,
      EventPayloadId = dto.EventPayloadId,
      Position = dto.Position,
    };
  }
}

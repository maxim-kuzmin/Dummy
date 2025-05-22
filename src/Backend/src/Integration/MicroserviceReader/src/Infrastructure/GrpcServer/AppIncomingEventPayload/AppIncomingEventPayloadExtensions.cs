namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcServer.AppIncomingEventPayload;

/// <summary>
/// Расширения полезной нагрузки входящего события приложения.
/// </summary>
public static class AppIncomingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventPayloadDeleteActionRequest ToAppIncomingEventPayloadDeleteActionRequest(
    this AppIncomingEventPayloadDeleteGrpcRequest request)
  {
    AppIncomingEventPayloadDeleteCommand command = new(request.ObjectId);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventPayloadGetActionRequest ToAppIncomingEventPayloadGetActionRequest(
    this AppIncomingEventPayloadGetGrpcRequest request)
  {
    AppIncomingEventPayloadSingleQuery query = new(request.ObjectId);

    return new(query);
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
      AppIncomingEventObjectId = dto.AppIncomingEventObjectId,
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
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventPayloadGetListActionRequest ToAppIncomingEventPayloadGetListActionRequest(
    this AppIncomingEventPayloadGetListGrpcRequest request)
  {
    AppIncomingEventPayloadPageQuery query = new(
      Page: new(request.Page.Number, request.Page.Size),
      Sort: new(request.Sort.Field, request.Sort.IsDesc),
      Filter: new(request.Filter.FullTextSearchQuery));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения списка полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppIncomingEventPayloadGetListGrpcReply ToAppIncomingEventPayloadGetListGrpcReply(
    this AppIncomingEventPayloadPageDTO dto)
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
  /// Преобразовать к запросу действия по сохранению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns
  public static AppIncomingEventPayloadSaveActionCommand ToAppIncomingEventPayloadSaveActionRequest(
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

    AppIncomingEventPayloadSaveCommand command = new(
      IsUpdate: false,
      ObjectId: string.Empty,
      Data: new(AppIncomingEventObjectId: request.AppIncomingEventObjectId, Payload: payload));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns
  public static AppIncomingEventPayloadSaveActionCommand ToAppIncomingEventPayloadSaveActionRequest(
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

    AppIncomingEventPayloadSaveCommand command = new(
      IsUpdate: true,
      ObjectId: request.ObjectId,
      Data: new(AppIncomingEventObjectId: request.AppIncomingEventObjectId, Payload: payload));

    return new(command);
  }

  private static AppIncomingEventPayloadGetListGrpcReplyItem ToAppIncomingEventPayloadGetListGrpcReplyItem(
    this AppIncomingEventPayloadSingleDTO dto)
  {
    return new()
    {
      ObjectId = dto.ObjectId,
      AppIncomingEventObjectId = dto.AppIncomingEventObjectId,
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

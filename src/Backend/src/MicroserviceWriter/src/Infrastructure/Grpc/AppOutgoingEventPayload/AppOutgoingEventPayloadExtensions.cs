namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.AppOutgoingEventPayload;

/// <summary>
/// Расширения полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по удалению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadDeleteActionCommand ToAppOutgoingEventPayloadDeleteActionCommand(
    this AppOutgoingEventPayloadDeleteGrpcRequest request)
  {
    return new(request.Id);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static AppOutgoingEventPayloadGetActionQuery ToAppOutgoingEventPayloadGetActionQuery(
    this AppOutgoingEventPayloadGetGrpcRequest request)
  {
    return new(request.Id);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppOutgoingEventPayloadGetGrpcReply ToAppOutgoingEventPayloadGetGrpcReply(
    this AppOutgoingEventPayloadSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      AppOutgoingEventId = dto.AppOutgoingEventId,
      Data = dto.Data,
      EntityConcurrencyTokenToDelete = dto.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = dto.EntityConcurrencyTokenToInsert,
      EntityId = dto.EntityId,
      EntityName = dto.EntityName,
      Position = dto.Position,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка полезных нагрузок исходящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static AppOutgoingEventPayloadGetListActionQuery ToAppOutgoingEventPayloadGetListActionQuery(
    this AppOutgoingEventPayloadGetListGrpcRequest request)
  {
    AppOutgoingEventPayloadPageQuery pageQuery = new()
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
  /// Преобразовать к отклику gRPC получения списка полезных нагрузок исходящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppOutgoingEventPayloadGetListGrpcReply ToAppOutgoingEventPayloadGetListGrpcReply(
    this AppOutgoingEventPayloadListDTO dto)
  {
    AppOutgoingEventPayloadGetListGrpcReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppOutgoingEventPayloadGetListGrpcReplyItem item = new()
      {
        Id = itemDTO.Id,
        AppOutgoingEventId = itemDTO.AppOutgoingEventId,
        Data = itemDTO.Data,
        EntityConcurrencyTokenToDelete = itemDTO.EntityConcurrencyTokenToDelete,
        EntityConcurrencyTokenToInsert = itemDTO.EntityConcurrencyTokenToInsert,
        EntityId = itemDTO.EntityId,
        EntityName = itemDTO.EntityName,
        Position = itemDTO.Position,
      };

      result.Items.Add(item);
    }

    return result;
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionCommand ToAppOutgoingEventPayloadSaveActionCommand(
    this AppOutgoingEventPayloadCreateGrpcRequest request)
  {
    AppEventPayloadWithDataAsString payload = new(request.Data)
    {
      EntityConcurrencyTokenToDelete = request.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = request.EntityConcurrencyTokenToInsert,
      EntityId = request.EntityId,
      EntityName = request.EntityName,
      Position = request.Position
    };

    return new(false, 0, request.AppOutgoingEventId, payload);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionCommand ToAppOutgoingEventPayloadSaveActionCommand(
    this AppOutgoingEventPayloadUpdateGrpcRequest request)
  {
    AppEventPayloadWithDataAsString payload = new(request.Data)
    {
      EntityConcurrencyTokenToDelete = request.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = request.EntityConcurrencyTokenToInsert,
      EntityId = request.EntityId,
      EntityName = request.EntityName,
      Position = request.Position
    };

    return new(true, request.Id, request.AppOutgoingEventId, payload);
  }
}

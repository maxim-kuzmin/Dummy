namespace Makc.Dummy.Writer.Infrastructure.Grpc.AppOutgoingEventPayload;

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
    this AppOutgoingEventPayloadDeleteActionRequest request)
  {
    return new(request.Id);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static AppOutgoingEventPayloadGetActionQuery ToAppOutgoingEventPayloadGetActionQuery(
    this AppOutgoingEventPayloadGetActionRequest request)
  {
    return new()
    {
      Id = request.Id
    };
  }

  /// <summary>
  /// Преобразовать к отклику gRPC действия по получению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppOutgoingEventPayloadGetActionReply ToAppOutgoingEventPayloadGetActionReply(
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
    this AppOutgoingEventPayloadGetListActionRequest request)
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
  /// Преобразовать к отклику gRPC действия по получению списка полезных нагрузок исходящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppOutgoingEventPayloadGetListActionReply ToAppOutgoingEventPayloadGetListActionReply(
    this AppOutgoingEventPayloadListDTO dto)
  {
    AppOutgoingEventPayloadGetListActionReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppOutgoingEventPayloadGetListActionReplyItem item = new()
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
    this AppOutgoingEventPayloadCreateActionRequest request)
  {
    AppEventPayloadWithDataAsString payload = new(request.Data)
    {
      EntityConcurrencyTokenToDelete = request.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = request.EntityConcurrencyTokenToInsert,
      EntityId = request.EntityId,
      EntityName = request.EntityName,
      Position = request.Position
    };

    return new(0, request.AppOutgoingEventId, payload);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionCommand ToAppOutgoingEventPayloadSaveActionCommand(
    this AppOutgoingEventPayloadUpdateActionRequest request)
  {
    AppEventPayloadWithDataAsString payload = new(request.Data)
    {
      EntityConcurrencyTokenToDelete = request.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = request.EntityConcurrencyTokenToInsert,
      EntityId = request.EntityId,
      EntityName = request.EntityName,
      Position = request.Position
    };

    return new(request.Id, request.AppOutgoingEventId, payload);
  }
}

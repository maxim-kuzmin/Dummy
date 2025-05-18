using Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.AppOutgoingEvent;
using static Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.AppOutgoingEventPayload.AppOutgoingEventPayload;

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
  public static AppOutgoingEventPayloadDeleteActionRequest ToAppOutgoingEventPayloadDeleteActionCommand(
    this AppOutgoingEventPayloadDeleteGrpcRequest request)
  {
    AppOutgoingEventPayloadDeleteCommand command = new(request.Id);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static AppOutgoingEventPayloadGetActionRequest ToAppOutgoingEventPayloadGetActionQuery(
    this AppOutgoingEventPayloadGetGrpcRequest request)
  {
    AppOutgoingEventPayloadSingleQuery query = new(request.Id);

    return new(query);
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
  public static AppOutgoingEventPayloadGetListActionRequest ToAppOutgoingEventPayloadGetListActionQuery(
    this AppOutgoingEventPayloadGetListGrpcRequest request)
  {
    AppOutgoingEventPayloadPageQuery query = new(    
      Page: new(request.Page.Number, request.Page.Size),
      Sort: new(request.Sort.Field, request.Sort.IsDesc),
      Filter: new(request.Filter.FullTextSearchQuery));

    return new(query);
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
  public static AppOutgoingEventPayloadSaveActionRequest ToAppOutgoingEventPayloadSaveActionCommand(
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

    AppOutgoingEventPayloadSaveCommand command = new(
      IsUpdate: false,
      Id: 0,
      Data: new(AppOutgoingEventId: request.AppOutgoingEventId, Payload: payload));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionRequest ToAppOutgoingEventPayloadSaveActionCommand(
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

    AppOutgoingEventPayloadSaveCommand command = new(
      IsUpdate: true,
      Id: request.Id,
      Data: new(AppOutgoingEventId: request.AppOutgoingEventId, Payload: payload));

    return new(command);
  }
}

﻿namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.GrpcServer.AppIncomingEvent;

/// <summary>
/// Расширения входящего события приложения.
/// </summary>
public static class AppIncomingEventExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventDeleteActionRequest ToAppIncomingEventDeleteActionRequest(
    this AppIncomingEventDeleteGrpcRequest request)
  {
    AppIncomingEventDeleteCommand command = new(request.ObjectId);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventGetActionRequest ToAppIncomingEventGetActionRequest(
    this AppIncomingEventGetGrpcRequest request)
  {
    AppIncomingEventSingleQuery query = new(request.ObjectId);

    return new(query);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения входящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppIncomingEventGetGrpcReply ToAppIncomingEventGetGrpcReply(this AppIncomingEventSingleDTO dto)
  {
    return new()
    {
      ObjectId = dto.ObjectId,
      ConcurrencyToken = dto.ConcurrencyToken,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      EventId = dto.EventId,
      EventName = dto.EventName,
      LastLoadingAt = Timestamp.FromDateTimeOffset(dto.LastLoadingAt ?? default),
      LastLoadingError = dto.LastLoadingError,
      LoadedAt = Timestamp.FromDateTimeOffset(dto.LoadedAt ?? default),
      PayloadCount = dto.PayloadCount,
      PayloadTotalCount = dto.PayloadTotalCount,
      ProcessedAt = Timestamp.FromDateTimeOffset(dto.ProcessedAt ?? default),
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка входящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventGetListActionRequest ToAppIncomingEventGetListActionRequest(
    this AppIncomingEventGetListGrpcRequest request)
  {
    AppIncomingEventListQuery query = new(
      MaxCount: request.MaxCount,
      Sort: new(Field: request.Sort.Field, IsDesc: request.Sort.IsDesc),
      Filter: new(FullTextSearchQuery: request.Filter.FullTextSearchQuery));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению страницы входящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventGetPageActionRequest ToAppIncomingEventGetPageActionRequest(
    this AppIncomingEventGetPageGrpcRequest request)
  {
    AppIncomingEventPageQuery query = new(
      Page: new(Number: request.Page.Number, Size: request.Page.Size),
      Sort: new(Field: request.Sort.Field, IsDesc: request.Sort.IsDesc),
      Filter: new(FullTextSearchQuery: request.Filter.FullTextSearchQuery));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения списка входящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppIncomingEventGetListGrpcReply ToAppIncomingEventGetListGrpcReply(
    this List<AppIncomingEventSingleDTO> dto)
  {
    AppIncomingEventGetListGrpcReply result = new();

    foreach (var itemDTO in dto)
    {
      result.Items.Add(itemDTO.ToAppIncomingEventGetListGrpcReplyItem());
    }

    return result;
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения страницы входящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppIncomingEventGetPageGrpcReply ToAppIncomingEventGetPageGrpcReply(
    this AppIncomingEventPageDTO dto)
  {
    AppIncomingEventGetPageGrpcReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      result.Items.Add(itemDTO.ToAppIncomingEventGetListGrpcReplyItem());
    }

    return result;
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventSaveActionRequest ToAppIncomingEventSaveActionRequest(
    this AppIncomingEventCreateGrpcRequest request)
  {
    var lastLoadingAt = request.LastLoadingAt.ToDateTimeOffset();
    var lastProcessingAt = request.LastProcessingAt.ToDateTimeOffset();
    var loadedAt = request.LoadedAt.ToDateTimeOffset();
    var processedAt = request.ProcessedAt.ToDateTimeOffset();

    AppIncomingEventSaveCommand command = new(
      IsUpdate: false,
      ObjectId: string.Empty,
      Data: new(
        EventId: request.EventId,
        EventName: request.EventName,
        LastLoadingAt: lastLoadingAt == default ? null : lastLoadingAt,
        LastLoadingError:request.LastLoadingError,
        LastProcessingAt: lastProcessingAt == default ? null : lastProcessingAt,
        LastProcessingError: request.LastProcessingError,
        LoadedAt: loadedAt == default ? null : loadedAt,
        PayloadCount: request.PayloadCount,
        PayloadTotalCount: request.PayloadTotalCount,
        ProcessedAt: processedAt == default ? null : processedAt));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventSaveActionRequest ToAppIncomingEventSaveActionRequest(
    this AppIncomingEventUpdateGrpcRequest request)
  {
    var lastLoadingAt = request.LastLoadingAt.ToDateTimeOffset();
    var lastProcessingAt = request.LastProcessingAt.ToDateTimeOffset();
    var loadedAt = request.LoadedAt.ToDateTimeOffset();
    var processedAt = request.ProcessedAt.ToDateTimeOffset();

    AppIncomingEventSaveCommand command = new(
      IsUpdate: true,
      ObjectId: request.ObjectId,
      Data: new(
        EventId: request.EventId,
        EventName: request.EventName,
        LastLoadingAt: lastLoadingAt == default ? null : lastLoadingAt,
        LastLoadingError: request.LastLoadingError,
        LastProcessingAt: lastProcessingAt == default ? null : lastProcessingAt,
        LastProcessingError: request.LastProcessingError,
        LoadedAt: loadedAt == default ? null : loadedAt,
        PayloadCount: request.PayloadCount,
        PayloadTotalCount: request.PayloadTotalCount,
        ProcessedAt: processedAt == default ? null : processedAt));

    return new(command);
  }

  private static AppIncomingEventGetListGrpcReplyItem ToAppIncomingEventGetListGrpcReplyItem(
    this AppIncomingEventSingleDTO dto)
  {
    return new()
    {
      ObjectId = dto.ObjectId,
      ConcurrencyToken = dto.ConcurrencyToken,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      EventId = dto.EventId,
      EventName = dto.EventName,
      LastLoadingAt = Timestamp.FromDateTimeOffset(dto.LastLoadingAt ?? default),
      LastLoadingError = dto.LastLoadingError,
      LoadedAt = Timestamp.FromDateTimeOffset(dto.LoadedAt ?? default),
      PayloadCount = dto.PayloadCount,
      PayloadTotalCount = dto.PayloadTotalCount,
      ProcessedAt = Timestamp.FromDateTimeOffset(dto.ProcessedAt ?? default),
    };
  }
}

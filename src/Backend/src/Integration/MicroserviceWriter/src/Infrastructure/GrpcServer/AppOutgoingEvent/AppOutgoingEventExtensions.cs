namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcServer.AppOutgoingEvent;

/// <summary>
/// Расширения исходящего события приложения.
/// </summary>
public static class AppOutgoingEventExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventDeleteActionRequest ToAppOutgoingEventDeleteActionRequest(
    this AppOutgoingEventDeleteGrpcRequest request)
  {
    AppOutgoingEventDeleteCommand command = new(request.Id);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventGetActionRequest ToAppOutgoingEventGetActionRequest(
    this AppOutgoingEventGetGrpcRequest request)
  {
    AppOutgoingEventSingleQuery query = new(request.Id);

    return new(query);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения исходящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppOutgoingEventGetGrpcReply ToAppOutgoingEventGetGrpcReply(this AppOutgoingEventSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      Name = dto.Name,
      PublishedAt = Timestamp.FromDateTimeOffset(dto.PublishedAt ?? default)
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка исходящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventGetListActionRequest ToAppOutgoingEventGetListActionRequest(
    this AppOutgoingEventGetListGrpcRequest request)
  {
    AppOutgoingEventListQuery query = new(
      MaxCount: request.MaxCount,
      Sort: new(Field: request.Sort.Field, IsDesc: request.Sort.IsDesc),
      Filter: new(FullTextSearchQuery: request.Filter.FullTextSearchQuery));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению страницы исходящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventGetPageActionRequest ToAppOutgoingEventGetPageActionRequest(
    this AppOutgoingEventGetPageGrpcRequest request)
  {
    AppOutgoingEventPageQuery query = new(
      Page: new(Number: request.Page.Number, Size: request.Page.Size),
      Sort: new(Field: request.Sort.Field, IsDesc: request.Sort.IsDesc),
      Filter: new(FullTextSearchQuery: request.Filter.FullTextSearchQuery));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения списка исходящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppOutgoingEventGetListGrpcReply ToAppOutgoingEventGetListGrpcReply(
    this List<AppOutgoingEventSingleDTO> dto)
  {
    AppOutgoingEventGetListGrpcReply result = new();

    foreach (var itemDTO in dto)
    {
      result.Items.Add(itemDTO.ToAppOutgoingEventGetListGrpcReplyItem());
    }

    return result;
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения страницы исходящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppOutgoingEventGetPageGrpcReply ToAppOutgoingEventGetPageGrpcReply(
    this AppOutgoingEventPageDTO dto)
  {
    AppOutgoingEventGetPageGrpcReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      result.Items.Add(itemDTO.ToAppOutgoingEventGetListGrpcReplyItem());
    }

    return result;
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventSaveActionRequest ToAppOutgoingEventSaveActionRequest(
    this AppOutgoingEventCreateGrpcRequest request)
  {
    var publishedAt = request.PublishedAt.ToDateTimeOffset();

    AppOutgoingEventSaveCommand command = new(
      IsUpdate: false,
      Id: 0,
      Data: new(Name: request.Name, PublishedAt: publishedAt == default ? null : publishedAt));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventSaveActionRequest ToAppOutgoingEventSaveActionRequest(
    this AppOutgoingEventUpdateGrpcRequest request)
  {
    var publishedAt = request.PublishedAt.ToDateTimeOffset();

    AppOutgoingEventSaveCommand command = new(
      IsUpdate: true,
      Id: request.Id,
      Data: new(Name: request.Name, PublishedAt: publishedAt == default ? null : publishedAt));

    return new(command);
  }

  private static AppOutgoingEventGetListGrpcReplyItem ToAppOutgoingEventGetListGrpcReplyItem(
    this AppOutgoingEventSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      Name = dto.Name,
      PublishedAt = Timestamp.FromDateTimeOffset(dto.PublishedAt ?? default)
    };
  }
}

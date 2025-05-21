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
    AppOutgoingEventPageQuery query = new(
      Page: new(request.Page.Number, request.Page.Size),
      Sort: new(request.Sort.Field, request.Sort.IsDesc),
      Filter: new(request.Filter.FullTextSearchQuery));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения списка исходящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppOutgoingEventGetListGrpcReply ToAppOutgoingEventGetListGrpcReply(
    this AppOutgoingEventPageDTO dto)
  {
    AppOutgoingEventGetListGrpcReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppOutgoingEventGetListGrpcReplyItem item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
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
}

namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.AppOutgoingEvent;

/// <summary>
/// Расширения исходящего события приложения.
/// </summary>
public static class AppOutgoingEventExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по удалению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventDeleteActionCommand ToAppOutgoingEventDeleteActionCommand(
    this AppOutgoingEventDeleteGrpcRequest request)
  {
    return new(request.Id);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static AppOutgoingEventGetActionQuery ToAppOutgoingEventGetActionQuery(
    this AppOutgoingEventGetGrpcRequest request)
  {
    return new(request.Id);
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
  /// <returns>Запрос.</returns>
  public static AppOutgoingEventGetListActionQuery ToAppOutgoingEventGetListActionQuery(
    this AppOutgoingEventGetListGrpcRequest request)
  {
    AppOutgoingEventPageQuery pageQuery = new()
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
  /// Преобразовать к отклику gRPC получения списка исходящих событий приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static AppOutgoingEventGetListGrpcReply ToAppOutgoingEventGetListGrpcReply(
    this AppOutgoingEventListDTO dto)
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
  /// Преобразовать к команде действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveActionCommand ToAppOutgoingEventSaveActionCommand(
    this AppOutgoingEventCreateGrpcRequest request)
  {
    var publishedAt = request.PublishedAt.ToDateTimeOffset();

    return new(false, 0, request.Name, publishedAt == default ? null : publishedAt);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveActionCommand ToAppOutgoingEventSaveActionCommand(
    this AppOutgoingEventUpdateGrpcRequest request)
  {
    var publishedAt = request.PublishedAt.ToDateTimeOffset();

    return new(true, request.Id, request.Name, publishedAt == default ? null : publishedAt);
  }
}

namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.AppOutgoingEvent;

/// <summary>
/// Расширения исходящего события приложения.
/// </summary>
public static class AppOutgoingEventExtensions
{
  /// <summary>
  /// Преобразовать к запросу gRPC создания исходящего события приложения.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventCreateGrpcRequest ToAppOutgoingEventCreateGrpcRequest(
    this AppOutgoingEventCommandDataSection data)
  {
    return new AppOutgoingEventCreateGrpcRequest
    {
      Name = data.Name,
      PublishedAt = Timestamp.FromDateTimeOffset(data.PublishedAt ?? default),
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC удаления исходящего события приложения.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventDeleteGrpcRequest ToAppOutgoingEventDeleteGrpcRequest(
    this AppOutgoingEventDeleteCommand command)
  {
    return new AppOutgoingEventDeleteGrpcRequest
    {
      Id = command.Id,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения исходящего события приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventGetGrpcRequest ToAppOutgoingEventGetGrpcRequest(
    this AppOutgoingEventSingleQuery query)
  {
    return new AppOutgoingEventGetGrpcRequest
    {
      Id = query.Id,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения списка исходящих событий приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventGetListGrpcRequest ToAppOutgoingEventGetListGrpcRequest(
    this AppOutgoingEventListQuery query)
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
  /// Преобразовать к запросу gRPC получения страницы исходящих событий приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventGetPageGrpcRequest ToAppOutgoingEventGetPageGrpcRequest(
    this AppOutgoingEventPageQuery query)
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
  /// Преобразовать к списку исходящих событий приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Список исходящих событий приложения.</returns>
  public static List<AppOutgoingEventSingleDTO> ToAppOutgoingEventListDTO(this AppOutgoingEventGetListGrpcReply reply)
  {
    return reply.Items.ToAppOutgoingEventListDTO();
  }

  /// <summary>
  /// Преобразовать к странице исходящих событий приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Страница исходящих событий приложения.</returns>
  public static AppOutgoingEventPageDTO ToAppOutgoingEventPageDTO(this AppOutgoingEventGetPageGrpcReply reply)
  {
    var items = reply.Items.ToAppOutgoingEventListDTO();

    return items.ToAppOutgoingEventPageDTO(reply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к исходящему событию приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Исходящее событие приложения.</returns>
  public static AppOutgoingEventSingleDTO ToAppOutgoingEventSingleDTO(this AppOutgoingEventGetGrpcReply reply)
  {
    var publishedAt = reply.PublishedAt.ToDateTimeOffset();

    return new()
    {
      Id = reply.Id,
      ConcurrencyToken = reply.ConcurrencyToken,
      CreatedAt = reply.CreatedAt.ToDateTimeOffset(),
      Name = reply.Name,
      PublishedAt = publishedAt == default ? null : publishedAt
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC обновления исходящего события приложения.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <param name="id">Идентификатор.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppOutgoingEventUpdateGrpcRequest ToAppOutgoingEventUpdateGrpcRequest(
    this AppOutgoingEventCommandDataSection data,
    long id)
  {
    return new AppOutgoingEventUpdateGrpcRequest
    {
      Id = id,
      Name = data.Name,
      PublishedAt = Timestamp.FromDateTimeOffset(data.PublishedAt ?? default),
    };
  }

  private static List<AppOutgoingEventSingleDTO> ToAppOutgoingEventListDTO(
    this RepeatedField<AppOutgoingEventGetListGrpcReplyItem> reply)
  {
    var result = new List<AppOutgoingEventSingleDTO>(reply.Count);

    foreach (var item in reply)
    {
      result.Add(item.ToAppOutgoingEventSingleDTO());
    }

    return result;
  }

  private static AppOutgoingEventSingleDTO ToAppOutgoingEventSingleDTO(
    this AppOutgoingEventGetListGrpcReplyItem reply)
  {
    var publishedAt = reply.PublishedAt.ToDateTimeOffset();

    return new()
    {
      Id = reply.Id,
      ConcurrencyToken = reply.ConcurrencyToken,
      CreatedAt = reply.CreatedAt.ToDateTimeOffset(),
      Name = reply.Name,
      PublishedAt = publishedAt == default ? null : publishedAt
    };
  }
}

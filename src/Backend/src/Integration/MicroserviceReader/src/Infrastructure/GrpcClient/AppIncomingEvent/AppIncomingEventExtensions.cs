using Ardalis.GuardClauses;

namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.AppIncomingEvent;

/// <summary>
/// Расширения входящего события приложения.
/// </summary>
public static class AppIncomingEventExtensions
{
  /// <summary>
  /// Преобразовать к запросу gRPC создания входящего события приложения.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventCreateGrpcRequest ToAppIncomingEventCreateGrpcRequest(
    this AppIncomingEventCommandDataSection data)
  {
    return new AppIncomingEventCreateGrpcRequest
    {
      EventId = data.EventId,
      EventName = data.EventName,
      LastLoadingAt = Timestamp.FromDateTimeOffset(data.LastLoadingAt ?? default),
      LastLoadingError = data.LastLoadingError,
      LoadedAt = Timestamp.FromDateTimeOffset(data.LoadedAt ?? default),
      PayloadCount = data.PayloadCount,
      PayloadTotalCount = data.PayloadTotalCount,
      ProcessedAt = Timestamp.FromDateTimeOffset(data.ProcessedAt ?? default)
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC удаления входящего события приложения.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventDeleteGrpcRequest ToAppIncomingEventDeleteGrpcRequest(
    this AppIncomingEventDeleteCommand command)
  {
    return new AppIncomingEventDeleteGrpcRequest
    {
      ObjectId = command.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения входящего события приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventGetGrpcRequest ToAppIncomingEventGetGrpcRequest(this AppIncomingEventSingleQuery query)
  {
    return new AppIncomingEventGetGrpcRequest
    {
      ObjectId = query.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения списка входящих событий приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventGetListGrpcRequest ToAppIncomingEventGetListGrpcRequest(
    this AppIncomingEventListQuery query)
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
  /// Преобразовать к запросу gRPC получения страницы входящих событий приложения.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventGetPageGrpcRequest ToAppIncomingEventGetPageGrpcRequest(
    this AppIncomingEventPageQuery query)
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
  /// Преобразовать к списку входящих событий приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Список входящих событий приложения.</returns>
  public static List<AppIncomingEventSingleDTO> ToAppIncomingEventListDTO(
    this AppIncomingEventGetListGrpcReply reply)
  {
    return reply.Items.ToAppIncomingEventListDTO();
  }

  /// <summary>
  /// Преобразовать к странице входящих событий приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Страница входящих событий приложения.</returns>
  public static AppIncomingEventPageDTO ToAppIncomingEventPageDTO(
    this AppIncomingEventGetPageGrpcReply reply)
  {
    var items = reply.Items.ToAppIncomingEventListDTO();

    return items.ToAppIncomingEventPageDTO(reply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к входящему событию приложения.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Входящее событие приложения.</returns>
  public static AppIncomingEventSingleDTO ToAppIncomingEventSingleDTO(this AppIncomingEventGetGrpcReply reply)
  {
    var lastLoadingAt = reply.LastLoadingAt.ToDateTimeOffset();
    var loadedAt = reply.LoadedAt.ToDateTimeOffset();
    var processedAt = reply.ProcessedAt.ToDateTimeOffset();

    return new()
    {
      ObjectId = reply.ObjectId,
      ConcurrencyToken = reply.ConcurrencyToken,
      CreatedAt = reply.CreatedAt.ToDateTimeOffset(),
      EventId = reply.EventId,
      EventName = reply.EventName,
      LastLoadingAt = lastLoadingAt == default ? null : lastLoadingAt,
      LastLoadingError = reply.LastLoadingError,
      LoadedAt = loadedAt == default ? null : loadedAt,
      PayloadCount = reply.PayloadCount,
      PayloadTotalCount = reply.PayloadTotalCount,
      ProcessedAt = processedAt == default ? null : processedAt,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC обновления входящего события приложения.
  /// </summary>
  /// <param name="data">Команда.</param>
  /// <param name="objectId">Идентификатор объекта.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AppIncomingEventUpdateGrpcRequest ToAppIncomingEventUpdateGrpcRequest(
    this AppIncomingEventCommandDataSection data,
    string? objectId)
  {
    Guard.Against.NullOrWhiteSpace(objectId);

    return new AppIncomingEventUpdateGrpcRequest
    {
      ObjectId = objectId,
      EventId = data.EventId,
      EventName = data.EventName,
      LastLoadingAt = Timestamp.FromDateTimeOffset(data.LastLoadingAt ?? default),
      LastLoadingError = data.LastLoadingError,
      LoadedAt = Timestamp.FromDateTimeOffset(data.LoadedAt ?? default),
      PayloadCount = data.PayloadCount,
      PayloadTotalCount = data.PayloadTotalCount,
      ProcessedAt = Timestamp.FromDateTimeOffset(data.ProcessedAt ?? default)
    };
  }

  private static List<AppIncomingEventSingleDTO> ToAppIncomingEventListDTO(
    this RepeatedField<AppIncomingEventGetListGrpcReplyItem> reply)
  {
    var result = new List<AppIncomingEventSingleDTO>(reply.Count);

    foreach (var item in reply)
    {
      result.Add(item.ToAppIncomingEventSingleDTO());
    }

    return result;
  }

  private static AppIncomingEventSingleDTO ToAppIncomingEventSingleDTO(
    this AppIncomingEventGetListGrpcReplyItem reply)
  {
    var lastLoadingAt = reply.LastLoadingAt.ToDateTimeOffset();
    var loadedAt = reply.LoadedAt.ToDateTimeOffset();
    var processedAt = reply.ProcessedAt.ToDateTimeOffset();

    return new()
    {
      ObjectId = reply.ObjectId,
      ConcurrencyToken = reply.ConcurrencyToken,
      CreatedAt = reply.CreatedAt.ToDateTimeOffset(),
      EventId = reply.EventId,
      EventName = reply.EventName,
      LastLoadingAt = lastLoadingAt == default ? null : lastLoadingAt,
      LastLoadingError = reply.LastLoadingError,
      LoadedAt = loadedAt == default ? null : loadedAt,
      PayloadCount = reply.PayloadCount,
      PayloadTotalCount = reply.PayloadTotalCount,
      ProcessedAt = processedAt == default ? null : processedAt,
    };
  }
}

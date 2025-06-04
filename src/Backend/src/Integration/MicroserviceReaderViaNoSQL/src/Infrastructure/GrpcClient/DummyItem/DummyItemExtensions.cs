using Ardalis.GuardClauses;

namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.GrpcClient.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к запросу gRPC создания фиктивного предмета.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Запрос gRPC.</returns>
  public static DummyItemCreateGrpcRequest ToDummyItemCreateGrpcRequest(
    this DummyItemCommandDataSection data)
  {
    return new DummyItemCreateGrpcRequest
    {
      Id = data.Id,
      Name = data.Name,
      ConcurrencyToken = data.ConcurrencyToken
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC удаления фиктивного предмета.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static DummyItemDeleteGrpcRequest ToDummyItemDeleteGrpcRequest(
    this DummyItemDeleteCommand command)
  {
    return new DummyItemDeleteGrpcRequest
    {
      ObjectId = command.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения фиктивного предмета.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static DummyItemGetGrpcRequest ToDummyItemGetGrpcRequest(this DummyItemSingleQuery query)
  {
    return new DummyItemGetGrpcRequest
    {
      ObjectId = query.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения списка фиктивных предметов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static DummyItemGetListGrpcRequest ToDummyItemGetListGrpcRequest(this DummyItemListQuery query)
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
  /// Преобразовать к запросу gRPC получения страницы фиктивных предметов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static DummyItemGetPageGrpcRequest ToDummyItemGetPageGrpcRequest(this DummyItemPageQuery query)
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
  /// Преобразовать к списку фиктивных предметов.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Список фиктивных предметов.</returns>
  public static List<DummyItemSingleDTO> ToDummyItemListDTO(this DummyItemGetListGrpcReply reply)
  {
    return reply.Items.ToDummyItemListDTO();
  }
  
  /// <summary>
  /// Преобразовать к странице фиктивных предметов.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Страница фиктивных предметов.</returns>
  public static DummyItemPageDTO ToDummyItemPageDTO(this DummyItemGetPageGrpcReply reply)
  {
    var items = reply.Items.ToDummyItemListDTO();

    return items.ToDummyItemPageDTO(reply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к фиктивному предмету.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Фиктивный предмет.</returns>
  public static DummyItemSingleDTO ToDummyItemSingleDTO(this DummyItemGetGrpcReply reply)
  {
    return new()
    {
      ObjectId = reply.ObjectId,
      Id = reply.Id,
      ConcurrencyToken = reply.ConcurrencyToken,
      Name = reply.Name,      
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC обновления фиктивного предмета.
  /// </summary>
  /// <param name="data">Команда.</param>
  /// <param name="objectId">Идентификатор объекта.</param>
  /// <returns>Запрос gRPC.</returns>
  public static DummyItemUpdateGrpcRequest ToDummyItemUpdateGrpcRequest(
    this DummyItemCommandDataSection data,
    string? objectId)
  {
    Guard.Against.NullOrWhiteSpace(objectId);

    return new DummyItemUpdateGrpcRequest
    {
      ObjectId = objectId,
      Id = data.Id,
      Name = data.Name,
      ConcurrencyToken = data.ConcurrencyToken
    };
  }

  private static List<DummyItemSingleDTO> ToDummyItemListDTO(this RepeatedField<DummyItemGetListGrpcReplyItem> reply)
  {
    var result = new List<DummyItemSingleDTO>(reply.Count);

    foreach (var item in reply)
    {
      result.Add(item.ToDummyItemSingleDTO());
    }

    return result;
  }

  private static DummyItemSingleDTO ToDummyItemSingleDTO(this DummyItemGetListGrpcReplyItem reply)
  {
    return new()
    {
      ObjectId = reply.ObjectId,
      Id = reply.Id,
      ConcurrencyToken = reply.ConcurrencyToken,
      Name = reply.Name,
    };
  }
}

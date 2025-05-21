namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.DummyItem;

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
      Name = data.Name,
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
      Id = command.Id,
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
      Id = query.Id,
    };
  }

  /// <summary>
  /// Преобразовать к запросу gRPC получения списка фиктивных предметов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос gRPC.</returns>
  public static DummyItemGetListGrpcRequest ToDummyItemGetListGrpcRequest(this DummyItemPageQuery query)
  {
    var filter = query.Filter;
    var page = query.Page;    
    var sort = query.Sort;

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
  /// Преобразовать к объекту передачи данных страницы фиктивных предметов.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static DummyItemPageDTO ToDummyItemPageDTO(this DummyItemGetListGrpcReply reply)
  {
    var items = new List<DummyItemSingleDTO>(reply.Items.Count);

    foreach (var itemReply in reply.Items)
    {
      DummyItemSingleDTO item = new(
        Id: itemReply.Id,
        ConcurrencyToken: itemReply.ConcurrencyToken,
        Name: itemReply.Name);

      items.Add(item);
    }

    return items.ToDummyItemPageDTO(reply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных единственного фиктивного предмета.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static DummyItemSingleDTO ToDummyItemSingleDTO(this DummyItemGetGrpcReply reply)
  {
    return new(reply.Id, reply.Name, reply.ConcurrencyToken);
  }

  /// <summary>
  /// Преобразовать к запросу gRPC обновления фиктивного предмета.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <param name="id">Идентификатор.</param>
  /// <returns>Запрос gRPC.</returns>
  public static DummyItemUpdateGrpcRequest ToDummyItemUpdateGrpcRequest(
    this DummyItemCommandDataSection data,
    long id)
  {
    return new DummyItemUpdateGrpcRequest
    {
      Id = id,
      Name = data.Name,
    };
  }
}

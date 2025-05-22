namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.DummyItem;

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
  /// <param name="listReply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static DummyItemPageDTO ToDummyItemPageDTO(this DummyItemGetListGrpcReply listReply)
  {
    var items = new List<DummyItemSingleDTO>(listReply.Items.Count);

    foreach (var reply in listReply.Items)
    {
      DummyItemSingleDTO item = new(
        ObjectId: reply.ObjectId,
        Id: reply.Id,
        Name: reply.Name,
        ConcurrencyToken: reply.ConcurrencyToken);

      items.Add(item);
    }

    return new(items, listReply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных единственного фиктивного предмета.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static DummyItemSingleDTO ToDummyItemSingleDTO(this DummyItemGetGrpcReply reply)
  {
    return new(
      ObjectId: reply.ObjectId,
      Id: reply.Id,
      Name: reply.Name,
      ConcurrencyToken: reply.ConcurrencyToken);
  }

  /// <summary>
  /// Преобразовать к запросу gRPC обновления фиктивного предмета.
  /// </summary>
  /// <param name="data">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static DummyItemUpdateGrpcRequest ToDummyItemUpdateGrpcRequest(
    this DummyItemCommandDataSection data,
    string objectId)
  {
    return new DummyItemUpdateGrpcRequest
    {
      ObjectId = objectId,
      Id = data.Id,
      Name = data.Name,
      ConcurrencyToken = data.ConcurrencyToken
    };
  }
}

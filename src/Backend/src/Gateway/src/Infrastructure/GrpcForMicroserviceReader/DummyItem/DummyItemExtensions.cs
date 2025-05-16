namespace Makc.Dummy.Gateway.Infrastructure.GrpcForMicroserviceReader.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по созданию фиктивного предмета.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по созданию фиктивного предмета.</returns>
  public static DummyItemCreateActionRequest ToDummyItemCreateActionRequest(
    this DummyItemCreateActionCommand command)
  {
    return new DummyItemCreateActionRequest
    {
      Id = command.Id,
      Name = command.Name,
      ConcurrencyToken = command.ConcurrencyToken
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по удалению фиктивного предмета.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по удалению фиктивного предмета.</returns>
  public static DummyItemDeleteActionRequest ToDummyItemDeleteActionRequest(
    this DummyItemDeleteActionCommand command)
  {
    return new DummyItemDeleteActionRequest
    {
      ObjectId = command.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия на получение фиктивного предмета.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос действия на получение фиктивного предмета.</returns>
  public static DummyItemGetActionRequest ToDummyItemGetActionRequest(this DummyItemSingleQuery query)
  {
    return new DummyItemGetActionRequest
    {
      ObjectId = query.ObjectId,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия на получение списка фиктивных предметов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос действия на получение списка фиктивных предметов.</returns>
  public static DummyItemGetListActionRequest ToDummyItemGetListActionRequest(this DummyItemListQuery query)
  {
    var filter = query.PageQuery.Filter;
    var page = query.PageQuery.Page;
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
  /// Преобразовать к объекту передачи данных списка фиктивных предметов.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных списка фиктивных предметов.</returns>
  public static DummyItemListDTO ToDummyItemListDTO(this DummyItemGetListActionReply reply)
  {
    var items = new List<DummyItemSingleDTO>(reply.Items.Count);

    foreach (var itemReply in reply.Items)
    {
      DummyItemSingleDTO item = new(
        itemReply.ObjectId,
        itemReply.Id,
        itemReply.Name,
        itemReply.ConcurrencyToken);

      items.Add(item);
    }

    return new(items, reply.TotalCount);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных фиктивного предмета.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных фиктивного предмета.</returns>
  public static DummyItemSingleDTO ToDummyItemSingleDTO(this DummyItemGetActionReply reply)
  {
    return new(reply.ObjectId, reply.Id, reply.Name, reply.ConcurrencyToken);
  }

  /// <summary>
  /// Преобразовать к запросу действия по обновлению фиктивного предмета.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по обновлению фиктивного предмета.</returns>
  public static DummyItemUpdateActionRequest ToDummyItemUpdateActionRequest(
    this DummyItemUpdateActionCommand command)
  {
    return new DummyItemUpdateActionRequest
    {
      ObjectId = command.ObjectId,
      Id = command.Id,
      Name = command.Name,
      ConcurrencyToken = command.ConcurrencyToken
    };
  }
}

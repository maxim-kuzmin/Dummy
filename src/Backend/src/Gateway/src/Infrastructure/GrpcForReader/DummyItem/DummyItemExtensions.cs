namespace Makc.Dummy.Gateway.Infrastructure.GrpcForReader.DummyItem;

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
  public static DummyItemGetActionRequest ToDummyItemGetActionRequest(this DummyItemGetActionQuery query)
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
  public static DummyItemGetListActionRequest ToDummyItemGetListActionRequest(
    this DummyItemGetListActionQuery query)
  {
    return new()
    {
      Page = new()
      {
        Number = query.Page.Number,
        Size = query.Page.Size
      },
      Sort = new()
      {
        Field = query.Sort.Field,        
        IsDesc = query.Sort.IsDesc
      },
      Filter = new()
      {
        FullTextSearchQuery = query.Filter.FullTextSearchQuery
      }
    };
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных действия по получению списка фиктивных предметов.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных действия по получению списка фиктивных предметов.</returns>
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
  /// Преобразовать к объекту передачи данных действия по получению фиктивного предмета.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных действия по получению фиктивного предмета.</returns>
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

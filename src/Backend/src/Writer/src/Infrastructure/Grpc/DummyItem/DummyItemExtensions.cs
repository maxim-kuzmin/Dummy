namespace Makc.Dummy.Writer.Infrastructure.Grpc.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по удалению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns>
  public static DummyItemDeleteActionCommand ToDummyItemDeleteActionCommand(
    this DummyItemDeleteActionRequest request)
  {
    return new(request.Id);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static DummyItemGetActionQuery ToDummyItemGetActionQuery(this DummyItemGetActionRequest request)
  {
    return new()
    {
      Id = request.Id
    };
  }

  /// <summary>
  /// Преобразовать к отклику gRPC действия по получению фиктивного предмета.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static DummyItemGetActionReply ToDummyItemGetActionReply(this DummyItemSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      Name = dto.Name,
      ConcurrencyToken = dto.ConcurrencyToken
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка фиктивных предметов.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static DummyItemGetListActionQuery ToDummyItemGetListActionQuery(
    this DummyItemGetListActionRequest request)
  {
    DummyItemPageQuery pageQuery = new()
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
  /// Преобразовать к отклику gRPC действия по получению списка фиктивных предметов.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static DummyItemGetListActionReply ToDummyItemGetListActionReply(this DummyItemListDTO dto)
  {
    DummyItemGetListActionReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      DummyItemGetListActionReplyItem item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
        ConcurrencyToken = itemDTO.ConcurrencyToken
      };

      result.Items.Add(item);
    }

    return result;
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns
  public static DummyItemSaveActionCommand ToDummyItemSaveActionCommand(
    this DummyItemCreateActionRequest request)
  {
    return new(0, request.Name);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns
  public static DummyItemSaveActionCommand ToDummyItemSaveActionCommand(
    this DummyItemUpdateActionRequest request)
  {
    return new(request.Id, request.Name);
  }
}

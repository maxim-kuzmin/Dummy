namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.DummyItem;

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
    this DummyItemDeleteGrpcRequest request)
  {
    return new(request.Id);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static DummyItemGetActionQuery ToDummyItemGetActionQuery(this DummyItemGetGrpcRequest request)
  {
    return new(request.Id);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения фиктивного предмета.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static DummyItemGetGrpcReply ToDummyItemGetGrpcReply(this DummyItemSingleDTO dto)
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
    this DummyItemGetListGrpcRequest request)
  {
    DummyItemPageQuery query = new(
      Page: new(request.Page.Number, request.Page.Size),
      Sort: new(request.Sort.Field, request.Sort.IsDesc),
      Filter: new(request.Filter.FullTextSearchQuery));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к отклику gRPC получения списка фиктивных предметов.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Отклик gRPC.</returns>
  public static DummyItemGetListGrpcReply ToDummyItemGetListGrpcReply(this DummyItemListDTO dto)
  {
    DummyItemGetListGrpcReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      DummyItemGetListGrpcReplyItem item = new()
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
    this DummyItemCreateGrpcRequest request)
  {
    return new(false, 0, request.Name);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns
  public static DummyItemSaveActionCommand ToDummyItemSaveActionCommand(
    this DummyItemUpdateGrpcRequest request)
  {
    return new(true, request.Id, request.Name);
  }
}

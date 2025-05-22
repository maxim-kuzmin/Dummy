namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcServer.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemDeleteActionRequest ToDummyItemDeleteActionRequest(
    this DummyItemDeleteGrpcRequest request)
  {
    DummyItemDeleteCommand command = new(request.ObjectId);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemGetActionRequest ToDummyItemGetActionRequest(this DummyItemGetGrpcRequest request)
  {
    DummyItemSingleQuery query = new(request.ObjectId);

    return new(query);
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
      ObjectId = dto.ObjectId,
      Id = dto.Id,
      Name = dto.Name,
      ConcurrencyToken = dto.ConcurrencyToken
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка фиктивных предметов.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemGetListActionRequest ToDummyItemGetListActionRequest(
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
  public static DummyItemGetListGrpcReply ToDummyItemGetListGrpcReply(this DummyItemPageDTO dto)
  {
    DummyItemGetListGrpcReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      DummyItemGetListGrpcReplyItem item = new()
      {
        ObjectId = itemDTO.ObjectId,
        Id = itemDTO.Id,
        Name = itemDTO.Name,
        ConcurrencyToken = itemDTO.ConcurrencyToken
      };

      result.Items.Add(item);
    }

    return result;
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns
  public static DummyItemSaveActionRequest ToDummyItemSaveActionRequest(
    this DummyItemCreateGrpcRequest request)
  {
    DummyItemSaveCommand command = new(
      IsUpdate: false,
      ObjectId: string.Empty,
      Data: new(request.Id, request.Name, request.ConcurrencyToken));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос действия.</returns
  public static DummyItemSaveActionRequest ToDummyItemSaveActionRequest(
    this DummyItemUpdateGrpcRequest request)
  {
    DummyItemSaveCommand command = new(
      IsUpdate: true,
      ObjectId: request.ObjectId,
      Data: new(request.Id, request.Name, request.ConcurrencyToken));

    return new(command);
  }
}

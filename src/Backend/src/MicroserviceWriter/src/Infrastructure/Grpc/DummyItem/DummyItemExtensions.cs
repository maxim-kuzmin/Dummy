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
  public static DummyItemDeleteActionRequest ToDummyItemDeleteActionCommand(
    this DummyItemDeleteGrpcRequest request)
  {
    DummyItemDeleteCommand command = new(Id: request.Id);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Запрос.</returns>
  public static DummyItemGetActionRequest ToDummyItemGetActionQuery(this DummyItemGetGrpcRequest request)
  {
    DummyItemSingleQuery query = new(Id: request.Id);

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
  public static DummyItemGetListActionRequest ToDummyItemGetListActionQuery(
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
  public static DummyItemSaveActionRequest ToDummyItemSaveActionCommand(
    this DummyItemCreateGrpcRequest request)
  {
    DummyItemSaveCommand command = new(
      IsUpdate: false,
      Id: 0,
      Data: new(Name: request.Name));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <returns>Команда.</returns
  public static DummyItemSaveActionRequest ToDummyItemSaveActionCommand(
    this DummyItemUpdateGrpcRequest request)
  {
    DummyItemSaveCommand command = new(
      IsUpdate: true,
      Id: request.Id,
      Data: new(Name: request.Name));

    return new(command);
  }
}

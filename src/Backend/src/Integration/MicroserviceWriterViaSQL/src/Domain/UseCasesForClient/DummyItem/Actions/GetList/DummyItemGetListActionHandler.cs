namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(IDummyItemQueryService _service) :
  IQueryHandler<DummyItemGetListActionRequest, Result<List<DummyItemSingleDTO>>>
{
  /// <inheritdoc/>
  public Task<Result<List<DummyItemSingleDTO>>> Handle(
    DummyItemGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request.Query, cancellationToken);
  }
}

namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(IDummyItemQueryService _service) :
  IRequestHandler<DummyItemGetListActionRequest, Result<List<DummyItemSingleDTO>>>
{
  /// <inheritdoc/>
  public ValueTask<Result<List<DummyItemSingleDTO>>> Handle(
    DummyItemGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<List<DummyItemSingleDTO>>>(_service.GetList(request.Query, cancellationToken));
  }
}

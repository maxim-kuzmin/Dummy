namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceReader.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(IDummyItemQueryService _service) :
  IQueryHandler<DummyItemGetListActionRequest, Result<DummyItemListDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemListDTO>> Handle(
    DummyItemGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetPage(request.Query, cancellationToken);
  }
}

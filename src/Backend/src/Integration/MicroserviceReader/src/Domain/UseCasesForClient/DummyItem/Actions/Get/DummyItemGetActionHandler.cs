namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCasesForClient.DummyItem.Actions.Get;

/// <summary>
/// Обработчик действия по получению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetActionHandler(IDummyItemQueryService _service) :
  IQueryHandler<DummyItemGetActionRequest, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemGetActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetSingle(request.Query, cancellationToken);
  }
}

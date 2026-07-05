namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.DummyItem.Actions.Get;

/// <summary>
/// Обработчик действия по получению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetActionHandler(IDummyItemQueryService _service) :
  IRequestHandler<DummyItemGetActionRequest, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<DummyItemSingleDTO>> Handle(
    DummyItemGetActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<DummyItemSingleDTO>>(_service.GetSingle(request.Query, cancellationToken));
  }
}

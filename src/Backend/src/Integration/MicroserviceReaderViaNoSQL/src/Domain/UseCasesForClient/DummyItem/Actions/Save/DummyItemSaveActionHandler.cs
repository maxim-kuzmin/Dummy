namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.DummyItem.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemSaveActionHandler(IDummyItemCommandService _service) :
  IRequestHandler<DummyItemSaveActionRequest, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<DummyItemSingleDTO>> Handle(
    DummyItemSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<DummyItemSingleDTO>>(_service.Save(request.Command, cancellationToken));
  }
}

namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceReader.DummyItem.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemSaveActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemSaveActionRequest, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.Save(request.Command, cancellationToken);
  }
}

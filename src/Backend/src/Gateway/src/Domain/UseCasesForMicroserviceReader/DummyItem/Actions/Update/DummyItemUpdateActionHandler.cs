namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceReader.DummyItem.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemUpdateActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemUpdateActionCommand, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Update(request, cancellationToken);
  }
}

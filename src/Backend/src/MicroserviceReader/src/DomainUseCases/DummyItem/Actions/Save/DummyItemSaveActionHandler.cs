namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemSaveActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemSaveActionCommand, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemSaveActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Save(request, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

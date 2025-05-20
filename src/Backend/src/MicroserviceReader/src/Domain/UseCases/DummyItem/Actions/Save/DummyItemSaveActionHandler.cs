namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.DummyItem.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemSaveActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemSaveActionRequest, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Save(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

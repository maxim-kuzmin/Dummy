namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemDeleteActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

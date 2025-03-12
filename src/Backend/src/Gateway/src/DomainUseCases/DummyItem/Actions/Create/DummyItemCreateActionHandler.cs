namespace Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;

/// <summary>
/// Обработчик действия по созданию фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemCreateActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemCreateActionCommand, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Create(request, cancellationToken);
  }
}

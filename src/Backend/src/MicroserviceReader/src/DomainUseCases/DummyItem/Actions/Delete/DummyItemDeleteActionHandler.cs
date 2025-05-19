namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemDeleteActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(DummyItemDeleteActionRequest request, CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

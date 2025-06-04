namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.DummyItem.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemDeleteActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(DummyItemDeleteActionRequest request, CancellationToken cancellationToken)
  {
    return _service.Delete(request.Command, cancellationToken);
  }
}

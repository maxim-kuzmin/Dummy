namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.DummyItem.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemDeleteActionHandler(IDummyItemCommandService _service) :
  IRequestHandler<DummyItemDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public ValueTask<Result> Handle(DummyItemDeleteActionRequest request, CancellationToken cancellationToken)
  {
    return new ValueTask<Result>(_service.Delete(request.Command, cancellationToken));
  }
}

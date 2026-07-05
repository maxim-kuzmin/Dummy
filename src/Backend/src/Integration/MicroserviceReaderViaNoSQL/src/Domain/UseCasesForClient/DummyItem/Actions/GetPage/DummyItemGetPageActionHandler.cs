namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.DummyItem.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы фиктивных предметов.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetPageActionHandler(IDummyItemQueryService _service) :
  IRequestHandler<DummyItemGetPageActionRequest, Result<DummyItemPageDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<DummyItemPageDTO>> Handle(
    DummyItemGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<DummyItemPageDTO>>(_service.GetPage(request.Query, cancellationToken));
  }
}

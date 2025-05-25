namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCasesForClient.DummyItem.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы фиктивных предметов.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetPageActionHandler(IDummyItemQueryService _service) :
  IQueryHandler<DummyItemGetPageActionRequest, Result<DummyItemPageDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemPageDTO>> Handle(
    DummyItemGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetPage(request.Query, cancellationToken);
  }
}

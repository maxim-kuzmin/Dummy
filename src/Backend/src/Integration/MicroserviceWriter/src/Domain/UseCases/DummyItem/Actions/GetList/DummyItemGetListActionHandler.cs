namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(IDummyItemQueryService _service) :
  IQueryHandler<DummyItemGetListActionRequest, Result<DummyItemPageDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemPageDTO>> Handle(
    DummyItemGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetPage(request.Query, cancellationToken);
  }
}

namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(
  AppSession _appSession,
  ILogger<DummyItemGetActionHandler> _logger,
  IDummyItemQueryService _service) : IQueryHandler<DummyItemGetListActionQuery, Result<DummyItemListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemListDTO>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    _logger.LogDebug("User name: {userName}", userName);

    var totalCount = await _service.GetCount(request.PageQuery, cancellationToken).ConfigureAwait(false);

    List<DummyItemSingleDTO> items;

    if (totalCount > 0)
    {
      items = await _service.GetList(request, cancellationToken).ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    DummyItemListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}

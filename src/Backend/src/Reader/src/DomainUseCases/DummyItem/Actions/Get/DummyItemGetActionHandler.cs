namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Get;

/// <summary>
/// Обработчик действия по получению фиктивного предмета.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemGetActionHandler(
  AppSession _appSession,
  ILogger<DummyItemGetActionHandler> _logger,
  IDummyItemQueryService _service) : IQueryHandler<DummyItemGetActionQuery, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    _logger.LogDebug("User name: {userName}", userName);

    var dto = await _service.GetAsync(request, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}

namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы фиктивных предметов.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemGetPageActionHandler(
  AppSession _appSession,
  ILogger<DummyItemGetPageActionHandler> _logger,
  IDummyItemQueryService _service) : IQueryHandler<DummyItemGetPageActionRequest, Result<DummyItemPageDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemPageDTO>> Handle(
    DummyItemGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    _logger.LogDebug("User name: {userName}", userName);

    var result = await _service.GetPage(request.Query, cancellationToken).ConfigureAwait(false);

    return Result.Success(result);
  }
}

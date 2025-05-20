namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(
  AppSession _appSession,
  ILogger<DummyItemGetActionHandler> _logger,
  IDummyItemQueryService _service) : IQueryHandler<DummyItemGetListActionRequest, Result<DummyItemListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemListDTO>> Handle(
    DummyItemGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    _logger.LogDebug("User name: {userName}", userName);

    var result = await _service.GetPage(request.Query, cancellationToken);

    return Result.Success(result);
  }
}

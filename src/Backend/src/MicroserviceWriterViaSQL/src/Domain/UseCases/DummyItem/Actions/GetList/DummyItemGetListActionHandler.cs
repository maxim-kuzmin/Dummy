namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(
  AppSession _appSession,
  ILogger<DummyItemGetListActionHandler> _logger,
  IDummyItemQueryService _service) :
  IQueryHandler<DummyItemGetListActionRequest, Result<List<DummyItemSingleDTO>>>
{
  /// <inheritdoc/>
  public async Task<Result<List<DummyItemSingleDTO>>> Handle(
    DummyItemGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    _logger.LogDebug("User name: {userName}", userName);

    var result = await _service.GetList(request.Query, cancellationToken).ConfigureAwait(false);

    return Result.Success(result);
  }
}

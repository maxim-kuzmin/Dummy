namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Actions.Get;

/// <summary>
/// Обработчик действия по получению фиктивного предмета.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemGetActionHandler(
  AppSession _appSession,
  ILogger<DummyItemGetActionHandler> _logger,
  IDummyItemQueryService _service) : IQueryHandler<DummyItemGetActionRequest, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemGetActionRequest request,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    _logger.LogDebug("User name: {userName}", userName);

    var result = await _service.GetSingle(request.Query, cancellationToken).ConfigureAwait(false);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}

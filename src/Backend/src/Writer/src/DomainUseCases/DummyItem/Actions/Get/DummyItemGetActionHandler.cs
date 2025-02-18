namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

/// <summary>
/// Обработчик действия по получению фиктивного предмета.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запроса базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_factory">Фабрика.</param>
public class DummyItemGetActionHandler(
  IAppDbQueryContext _appDbQueryContext,
  AppSession _appSession,
  ILogger<DummyItemGetActionHandler> _logger,
  IDummyItemGetActionFactory _factory) : IQueryHandler<DummyItemGetActionQuery, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    _logger.LogDebug("User name: {userName}", userName);

    var dbCommand = _factory.CreateDbCommand(request);

    var task = _appDbQueryContext.GetFirstOrDefaultAsync<DummyItemSingleDTO>(dbCommand, cancellationToken);

    var dto = await task.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}

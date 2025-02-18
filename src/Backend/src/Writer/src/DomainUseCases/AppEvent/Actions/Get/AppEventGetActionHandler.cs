namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению события приложения.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запроса базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
public class AppEventGetActionHandler(
  IAppDbQueryContext _appDbQueryContext,
  IAppEventGetActionFactory _factory) : IQueryHandler<AppEventGetActionQuery, Result<AppEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventSingleDTO>> Handle(
    AppEventGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var dbCommand = _factory.CreateDbCommand(request);

    var task = _appDbQueryContext.GetFirstOrDefaultAsync<AppEventSingleDTO>(dbCommand, cancellationToken);

    var dto = await task.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}

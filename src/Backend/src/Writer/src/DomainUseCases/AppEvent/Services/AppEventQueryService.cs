namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Services;

/// <summary>
/// Сервис запросов события приложения.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запросов базы данных приложения.</param>
/// <param name="_dbCommandFactory">Фабрика команд базы данных.</param>
public class AppEventQueryService(
  IAppDbQueryContext _appDbQueryContext,
  IAppEventDbSQLCommandFactory _dbCommandFactory) : IAppEventQueryService
{
  /// <inheritdoc/>
  public async Task<long> CountAsync(AppEventPageQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query);

    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetListAsync<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<AppEventSingleDTO?> GetAsync(AppEventSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefaultAsync<AppEventSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppEventSingleDTO>> ListAsync(AppEventListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.PageQuery);

    var dbCommandForItems = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.PageQuery.Page, query.Sort);

    return _appDbQueryContext.GetListAsync<AppEventSingleDTO>(dbCommandForItems, cancellationToken);
  }
}

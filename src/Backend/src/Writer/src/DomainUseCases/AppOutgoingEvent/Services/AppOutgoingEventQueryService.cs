namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Services;

/// <summary>
/// Сервис запросов исходящего события приложения.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запросов базы данных приложения.</param>
/// <param name="_dbCommandFactory">Фабрика команд базы данных.</param>
public class AppOutgoingEventQueryService(
  IAppDbSQLQueryContext _appDbQueryContext,
  IAppOutgoingEventDbSQLCommandFactory _dbCommandFactory) : IAppOutgoingEventQueryService
{
  /// <inheritdoc/>
  public async Task<long> CountAsync(AppOutgoingEventPageQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query);

    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetListAsync<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<AppOutgoingEventSingleDTO?> GetAsync(AppOutgoingEventSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefaultAsync<AppOutgoingEventSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppOutgoingEventSingleDTO>> ListAsync(AppOutgoingEventListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.PageQuery);

    var dbCommandForItems = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.PageQuery.Page, query.Sort);

    return _appDbQueryContext.GetListAsync<AppOutgoingEventSingleDTO>(dbCommandForItems, cancellationToken);
  }
}

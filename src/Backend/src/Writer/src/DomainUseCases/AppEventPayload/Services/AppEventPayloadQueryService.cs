namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки события приложения.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запросов базы данных приложения.</param>
/// <param name="_dbCommandFactory">Фабрика команд базы данных.</param>
public class AppEventPayloadQueryService(
  IAppDbSQLQueryContext _appDbQueryContext,
  IAppEventPayloadDbSQLCommandFactory _dbCommandFactory) : IAppEventPayloadQueryService
{
  /// <inheritdoc/>
  public async Task<long> CountAsync(AppEventPayloadPageQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query);

    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetListAsync<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<AppEventPayloadSingleDTO?> GetAsync(AppEventPayloadSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefaultAsync<AppEventPayloadSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppEventPayloadSingleDTO>> ListAsync(AppEventPayloadListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.PageQuery);

    var dbCommandForItems = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.PageQuery.Page, query.Sort);

    return _appDbQueryContext.GetListAsync<AppEventPayloadSingleDTO>(dbCommandForItems, cancellationToken);
  }
}

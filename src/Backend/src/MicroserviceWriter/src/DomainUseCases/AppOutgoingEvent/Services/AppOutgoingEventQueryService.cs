namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Services;

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
  public async Task<long> GetCount(AppOutgoingEventPageQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query);

    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetList<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<AppOutgoingEventSingleDTO?> GetSingle(AppOutgoingEventSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefault<AppOutgoingEventSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppOutgoingEventSingleDTO>> GetList(AppOutgoingEventListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.PageQuery);

    var dbCommandForItems = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.PageQuery.Page, query.Sort);

    return _appDbQueryContext.GetList<AppOutgoingEventSingleDTO>(dbCommandForItems, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<long>> GetUnpublishedIdList(
    AppOutgoingEventUnpublishedListQuery query,
    CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetList<long>(dbCommand, cancellationToken);
  }
}

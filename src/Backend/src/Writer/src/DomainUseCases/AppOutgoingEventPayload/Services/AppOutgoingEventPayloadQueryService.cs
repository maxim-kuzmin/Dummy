namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запросов базы данных приложения.</param>
/// <param name="_dbCommandFactory">Фабрика команд базы данных.</param>
public class AppOutgoingEventPayloadQueryService(
  IAppDbSQLQueryContext _appDbQueryContext,
  IAppOutgoingEventPayloadDbSQLCommandFactory _dbCommandFactory) : IAppOutgoingEventPayloadQueryService
{
  /// <inheritdoc/>
  public async Task<long> GetCount(AppOutgoingEventPayloadPageQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query);

    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetList<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<AppOutgoingEventPayloadSingleDTO?> GetSingle(AppOutgoingEventPayloadSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefault<AppOutgoingEventPayloadSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppOutgoingEventPayloadSingleDTO>> GetList(AppOutgoingEventPayloadListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.PageQuery);

    var dbCommandForItems = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.PageQuery.Page, query.Sort);

    return _appDbQueryContext.GetList<AppOutgoingEventPayloadSingleDTO>(dbCommandForItems, cancellationToken);
  }
}

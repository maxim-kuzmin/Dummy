namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Services;

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
  public Task<long> GetCount(AppOutgoingEventCountQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.Filter);

    return GetCount(dbCommandForFilter, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppOutgoingEventSingleDTO>> GetList(
    AppOutgoingEventListQuery query,
    CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.Filter);

    var dbCommand = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.Sort, query.MaxCount);

    return _appDbQueryContext.GetList<AppOutgoingEventSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<AppOutgoingEventPageDTO> GetPage(
    AppOutgoingEventPageQuery query,
    CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.Filter);

    var totalCount = await GetCount(dbCommandForFilter, cancellationToken).ConfigureAwait(false);

    var dbCommand = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.Sort, query.Page);

    List<AppOutgoingEventSingleDTO> items;

    if (totalCount > 0)
    {
      var task = _appDbQueryContext.GetList<AppOutgoingEventSingleDTO>(dbCommand, cancellationToken);

      items = await task.ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    return items.ToAppOutgoingEventPageDTO(totalCount);
  }

  /// <inheritdoc/>
  public Task<AppOutgoingEventSingleDTO?> GetSingle(
    AppOutgoingEventSingleQuery query,
    CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefault<AppOutgoingEventSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppOutgoingEventSingleDTO>> GetUnpublishedList(
    AppOutgoingEventUnpublishedListQuery query,
    CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetList<AppOutgoingEventSingleDTO>(dbCommand, cancellationToken);
  }

  private async Task<long> GetCount(DbSQLCommand dbCommandForFilter, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetList<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }
}

namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Services;

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
  public Task<long> GetCount(AppOutgoingEventPayloadCountQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.Filter);

    return GetCount(dbCommandForFilter, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppOutgoingEventPayloadSingleDTO>> GetList(
    AppOutgoingEventPayloadListQuery query,
    CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.Filter);

    var dbCommand = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.Sort);

    return _appDbQueryContext.GetList<AppOutgoingEventPayloadSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<AppOutgoingEventPayloadListDTO> GetPage(
    AppOutgoingEventPayloadPageQuery query,
    CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.Filter);

    var totalCount = await GetCount(dbCommandForFilter, cancellationToken).ConfigureAwait(false);

    var dbCommand = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.Sort, query.Page);

    List<AppOutgoingEventPayloadSingleDTO> items;

    if (totalCount > 0)
    {
      var task = _appDbQueryContext.GetList<AppOutgoingEventPayloadSingleDTO>(dbCommand, cancellationToken);

      items = await task.ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    return items.ToAppOutgoingEventPayloadListDTO(totalCount);
  }

  /// <inheritdoc/>
  public Task<AppOutgoingEventPayloadSingleDTO?> GetSingle(
    AppOutgoingEventPayloadSingleQuery query,
    CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefault<AppOutgoingEventPayloadSingleDTO>(dbCommand, cancellationToken);
  }

  private async Task<long> GetCount(DbSQLCommand dbCommandForFilter, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetList<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }
}

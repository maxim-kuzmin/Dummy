namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.DummyItem.Services;

/// <summary>
/// Сервис запросов фиктивного предмета.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запросов базы данных приложения.</param>
/// <param name="_dbCommandFactory">Фабрика команд базы данных.</param>
public class DummyItemQueryService(
  IAppDbSQLQueryContext _appDbQueryContext,
  IDummyItemDbSQLCommandFactory _dbCommandFactory) : IDummyItemQueryService
{
  /// <inheritdoc/>
  public Task<long> GetCount(DummyItemCountQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.Filter);

    return GetCount(dbCommandForFilter, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<DummyItemSingleDTO>> GetList(DummyItemListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.Filter);

    var dbCommand = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.Sort);

    return _appDbQueryContext.GetList<DummyItemSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<DummyItemPageDTO> GetPage(DummyItemPageQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.Filter);

    var totalCount = await GetCount(dbCommandForFilter, cancellationToken).ConfigureAwait(false);    

    var dbCommand = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.Sort, query.Page);

    List <DummyItemSingleDTO> items;

    if (totalCount > 0)
    {
      var task = _appDbQueryContext.GetList<DummyItemSingleDTO>(dbCommand, cancellationToken);

      items = await task.ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    return items.ToDummyItemPageDTO(totalCount);
  }

  /// <inheritdoc/>
  public Task<DummyItemSingleDTO?> GetSingle(DummyItemSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefault<DummyItemSingleDTO>(dbCommand, cancellationToken);
  }

  private async Task<long> GetCount(DbSQLCommand dbCommandForFilter, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetList<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }
}

namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem.Services;

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
  public async Task<long> GetCount(DummyItemPageQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query);

    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetList<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<List<DummyItemSingleDTO>> GetList(DummyItemListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.PageQuery);

    var dbCommandForItems = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.PageQuery.Page, query.Sort);

    return _appDbQueryContext.GetList<DummyItemSingleDTO>(dbCommandForItems, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<DummyItemSingleDTO?> GetSingle(DummyItemSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefault<DummyItemSingleDTO>(dbCommand, cancellationToken);
  }
}

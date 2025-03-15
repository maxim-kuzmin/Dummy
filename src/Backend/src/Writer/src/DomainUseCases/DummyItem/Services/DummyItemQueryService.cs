namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Services;

/// <summary>
/// Сервис запросов фиктивного предмета.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запросов базы данных приложения.</param>
/// <param name="_dbCommandFactory">Фабрика команд базы данных.</param>
public class DummyItemQueryService(
  IAppDbQueryContext _appDbQueryContext,
  IDummyItemDbSQLCommandFactory _dbCommandFactory) : IDummyItemQueryService
{
  /// <inheritdoc/>
  public async Task<long> CountAsync(DummyItemPageQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query);

    var dbCommand = _dbCommandFactory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var data = await _appDbQueryContext.GetListAsync<long>(dbCommand, cancellationToken).ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<DummyItemSingleDTO?> GetAsync(DummyItemSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _dbCommandFactory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefaultAsync<DummyItemSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<DummyItemSingleDTO>> ListAsync(DummyItemListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _dbCommandFactory.CreateDbCommandForFilter(query.PageQuery);

    var dbCommandForItems = _dbCommandFactory.CreateDbCommandForItems(dbCommandForFilter, query.PageQuery.Page, query.Sort);

    return _appDbQueryContext.GetListAsync<DummyItemSingleDTO>(dbCommandForItems, cancellationToken);
  }
}

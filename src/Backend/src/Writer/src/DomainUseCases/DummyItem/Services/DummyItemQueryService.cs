namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Services;

/// <summary>
/// Сервис запросов фиктивного предмета.
/// </summary>
public class DummyItemQueryService(
  IAppDbQueryContext _appDbQueryContext,
  IDummyItemFactory _factory) : IDummyItemQueryService
{
  /// <inheritdoc/>
  public async Task<long> CountAsync(DummyItemCountQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _factory.CreateDbCommandForFilter(query);

    var dbCommand = _factory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var task = _appDbQueryContext.GetListAsync<long>(dbCommand, cancellationToken);

    var data = await task.ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<DummyItemSingleDTO?> GetAsync(DummyItemSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _factory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefaultAsync<DummyItemSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<DummyItemSingleDTO>> ListAsync(DummyItemListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _factory.CreateDbCommandForFilter(query.CountQuery);

    var dbCommandForItems = _factory.CreateDbCommandForItems(dbCommandForFilter, query.Page);

    return _appDbQueryContext.GetListAsync<DummyItemSingleDTO>(dbCommandForItems, cancellationToken);
  }
}

namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadQueryService(
  IAppDbQueryContext _appDbQueryContext,
  IAppEventPayloadFactory _factory) : IAppEventPayloadQueryService
{
  /// <inheritdoc/>
  public async Task<long> CountAsync(AppEventPayloadPageQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _factory.CreateDbCommandForFilter(query);

    var dbCommand = _factory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var task = _appDbQueryContext.GetListAsync<long>(dbCommand, cancellationToken);

    var data = await task.ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<AppEventPayloadSingleDTO?> GetAsync(AppEventPayloadSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _factory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefaultAsync<AppEventPayloadSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppEventPayloadSingleDTO>> ListAsync(AppEventPayloadListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _factory.CreateDbCommandForFilter(query.PageQuery);

    var dbCommandForItems = _factory.CreateDbCommandForItems(dbCommandForFilter, query.PageQuery.Page, query.Order);

    return _appDbQueryContext.GetListAsync<AppEventPayloadSingleDTO>(dbCommandForItems, cancellationToken);
  }
}

﻿namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Services;

/// <summary>
/// Сервис запросов события приложения.
/// </summary>
public class AppEventQueryService(
  IAppDbQueryContext _appDbQueryContext,
  IAppEventFactory _factory) : IAppEventQueryService
{
  /// <inheritdoc/>
  public async Task<long> CountAsync(AppEventCountQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _factory.CreateDbCommandForFilter(query);

    var dbCommand = _factory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var task = _appDbQueryContext.GetListAsync<long>(dbCommand, cancellationToken);

    var data = await task.ConfigureAwait(false);

    return data[0];
  }

  /// <inheritdoc/>
  public Task<AppEventSingleDTO?> GetAsync(AppEventSingleQuery query, CancellationToken cancellationToken)
  {
    var dbCommand = _factory.CreateDbCommand(query);

    return _appDbQueryContext.GetFirstOrDefaultAsync<AppEventSingleDTO>(dbCommand, cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppEventSingleDTO>> ListAsync(AppEventListQuery query, CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _factory.CreateDbCommandForFilter(query.CountQuery);

    var dbCommandForItems = _factory.CreateDbCommandForItems(dbCommandForFilter, query.Page);

    return _appDbQueryContext.GetListAsync<AppEventSingleDTO>(dbCommandForItems, cancellationToken);
  }
}

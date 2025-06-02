using Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Commands;

namespace Makc.Dummy.MicroserviceReader.Infrastructure.MongoDB.AppIncomingEvent;

/// <summary>
/// Репозиторий входящего события приложения.
/// </summary>
/// <param name="appDbSettings">Настройки базы данных приложения.</param>
/// <param name="clientSessionHandle">Описатель сессии клиента.</param>
/// <param name="database">База данных.</param>
public class AppIncomingEventRepository(
  AppDbSettings appDbSettings,
  IClientSessionHandle clientSessionHandle,
  IMongoDatabase database) :
  AppRepositoryBase<AppIncomingEventEntity>(
    clientSessionHandle,
    database.GetCollection<AppIncomingEventEntity>(appDbSettings.Entities.AppIncomingEvent.Collection)),
  IAppIncomingEventRepository
{
  /// <inheritdoc/>
  public Task AddNotFoundByEvent(
    IEnumerable<AppIncomingEventEntity> entities,
    CancellationToken cancellationToken)
  {
    var requests = entities.Select(x => new UpdateOneModel<AppIncomingEventEntity>(
        filter: new ExpressionFilterDefinition<AppIncomingEventEntity>(
          xx => xx.EventId == x.EventId && xx.EventName == x.EventName),
        update: Builders<AppIncomingEventEntity>.Update
          .SetOnInsert(xx => xx.ConcurrencyToken, x.ConcurrencyToken)
          .SetOnInsert(xx => xx.CreatedAt, x.CreatedAt)
          .SetOnInsert(xx => xx.EventId, x.EventId)
          .SetOnInsert(xx => xx.EventName, x.EventName)
          .SetOnInsert(xx => xx.LastLoadingAt, x.LastLoadingAt)
          .SetOnInsert(xx => xx.LastLoadingError, x.LastLoadingError)
          .SetOnInsert(xx => xx.LoadedAt, x.LoadedAt)
          .SetOnInsert(xx => xx.PayloadCount, x.PayloadCount)
          .SetOnInsert(xx => xx.PayloadTotalCount, x.PayloadTotalCount)
          .SetOnInsert(xx => xx.ProcessedAt, x.ProcessedAt))
    { IsUpsert = true });

    return Collection.BulkWriteAsync(requests, cancellationToken: cancellationToken);
  }

  /// <inheritdoc/>
  public Task DeleteList(AppIncomingEventDeleteListCommand command, CancellationToken cancellationToken)
  {
    var filterBuilder = Builders<AppIncomingEventEntity>.Filter;

    var filter = filterBuilder.Empty;

    if (command.ObjectIds?.Count > 0)
    {
      filter = filterBuilder.Where(x => x.ObjectId != null && command.ObjectIds.Contains(x.ObjectId));
    }

    return Collection.DeleteManyAsync(ClientSessionHandle, filter, cancellationToken: cancellationToken);
  }

  /// <inheritdoc/>
  public Task<long> GetCount(AppIncomingEventCountQuery query, CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.Filter);

    return Collection.CountDocumentsAsync(ClientSessionHandle, filter, cancellationToken: cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventEntity>> GetList(
    AppIncomingEventListQuery query,
    CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.Filter);

    var found = Collection.Find(ClientSessionHandle, filter)
      .Sort(query.Sort, AppIncomingEventSettings.DefaultQuerySortSection, CreateSortFieldExpression)
      .TakeMaxCount(query.MaxCount);

    var result = await found.ToListAsync(cancellationToken).ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventEntity>> GetPageItems(
    AppIncomingEventPageQuery query,
    CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.Filter);

    var found = Collection.Find(ClientSessionHandle, filter)
      .Sort(query.Sort, DummyItemSettings.DefaultQuerySortSection, CreateSortFieldExpression)
      .TakePage(query.Page);

    var result = await found.ToListAsync(cancellationToken).ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public Task<List<string>> GetProcessedObjectIds(
    AppIncomingEventProcessedListQuery query,
    CancellationToken cancellationToken)
  {
    var filterBuilder = Builders<AppIncomingEventEntity>.Filter;

    var filter = filterBuilder.Where(x => x.ProcessedAt.HasValue);

    if (query.MaxDate.HasValue)
    {
      filter = filterBuilder.And(filter, filterBuilder.Where(x => x.ProcessedAt < query.MaxDate.Value));
    }

    return Collection.Find(ClientSessionHandle, filter).Project(x => x.ObjectId!).ToListAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventEntity?> GetSingle(
    AppIncomingEventSingleQuery query,
    CancellationToken cancellationToken)
  {
    if (query.ObjectId == null)
    {
      return null;
    }

    var filter = Builders<AppIncomingEventEntity>.Filter.Eq(x => x.ObjectId, query.ObjectId);

    var task = Collection.Find(ClientSessionHandle, filter).FirstOrDefaultAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public Task<List<AppIncomingEventEntity>> GetUnloadedList(
    AppIncomingEventNamedListQuery query,
    CancellationToken cancellationToken)
  {
    return GetNamedList(
      query,
      Builders<AppIncomingEventEntity>.Filter.Eq(x => x.LoadedAt, null),
      Builders<AppIncomingEventEntity>.Sort.Ascending(x => x.LastLoadingAt),
      cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<AppIncomingEventEntity>> GetUnprocessedList(
    AppIncomingEventNamedListQuery query,
    CancellationToken cancellationToken)
  {
    return GetNamedList(
      query,
      Builders<AppIncomingEventEntity>.Filter.Eq(x => x.ProcessedAt, null),
      Builders<AppIncomingEventEntity>.Sort.Ascending(x => x.LastProcessingAt),
      cancellationToken);
  }

  /// <inheritdoc/>
  protected sealed override Expression<Func<AppIncomingEventEntity, bool>> CreateFilterByPrimaryKey(
    string? primaryKey)
  {
    return x => x.ObjectId == primaryKey;
  }

  private static FilterDefinition<AppIncomingEventEntity> CreateFilter(
    AppIncomingEventQueryFilterSection? filterSection)
  {
    var filterBuilder = Builders<AppIncomingEventEntity>.Filter;

    var result = Builders<AppIncomingEventEntity>.Filter.Empty;

    if (!string.IsNullOrEmpty(filterSection?.FullTextSearchQuery))
    {
      Regex re = new($".*{filterSection.FullTextSearchQuery}.*", RegexOptions.IgnoreCase);

      result = filterBuilder.Or(
        filterBuilder.Regex(x => x.EventId, re),
        filterBuilder.Regex(x => x.EventName, re));
    }

    return result;
  }

  private static Expression<Func<AppIncomingEventEntity, object>> CreateSortFieldExpression(string field)
  {
    Expression<Func<AppIncomingEventEntity, object>> result;

    if (field.EqualsToSortField(AppIncomingEventSettings.SortFieldForId))
    {
      result = x => x.EventId;
    }
    else if (field.EqualsToSortField(AppIncomingEventSettings.SortFieldForName))
    {
      result = x => x.EventName;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }

  private async Task<List<AppIncomingEventEntity>> GetNamedList(
    AppIncomingEventNamedListQuery query,
    FilterDefinition<AppIncomingEventEntity> filterDefinition,
    SortDefinition<AppIncomingEventEntity> sortDefinition,
    CancellationToken cancellationToken)
  {
    var filterBuilder = Builders<AppIncomingEventEntity>.Filter;

    List<FilterDefinition<AppIncomingEventEntity>> filterDefinitions = [
      filterDefinition,
      filterBuilder.Eq(x => x.EventName, query.EventName)
    ];

    if (query.ObjectIds.Count > 0)
    {
      filterDefinitions.Add(filterBuilder.In(x => x.ObjectId, query.ObjectIds));
    }

    var filter = filterBuilder.And(filterDefinitions);

    IFindFluent<AppIncomingEventEntity, AppIncomingEventEntity> found = Collection
      .Find(ClientSessionHandle, filter)
      .Sort(sortDefinition.Ascending(x => x.EventId));

    if (query.MaxCount > 0)
    {
      found = found.Limit(query.MaxCount);
    }

    var result = await found.ToListAsync(cancellationToken).ConfigureAwait(false);

    return result;
  }

}

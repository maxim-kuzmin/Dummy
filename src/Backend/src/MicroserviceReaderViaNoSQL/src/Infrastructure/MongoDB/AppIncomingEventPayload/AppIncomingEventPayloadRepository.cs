using Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Commands;
using Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Commands;
using MongoDB.Driver;

namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Infrastructure.MongoDB.AppIncomingEventPayload;

/// <summary>
/// Репозиторий полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="appDbSettings">Настройки базы данных приложения.</param>
/// <param name="clientSessionHandle">Описатель сессии клиента.</param>
/// <param name="database">База данных.</param>
public class AppIncomingEventPayloadRepository(
  AppDbSettings appDbSettings,
  IClientSessionHandle clientSessionHandle,
  IMongoDatabase database) :
  AppRepositoryBase<AppIncomingEventPayloadEntity>(
    clientSessionHandle,
    database.GetCollection<AppIncomingEventPayloadEntity>(appDbSettings.Entities.AppIncomingEventPayload.Collection)),
  IAppIncomingEventPayloadRepository
{
  /// <inheritdoc/>
  public Task AddNotFoundByEventPayload(
    IEnumerable<AppIncomingEventPayloadEntity> entities,
    CancellationToken cancellationToken)
  {
    var requests = entities.Select(x => new UpdateOneModel<AppIncomingEventPayloadEntity>(
        filter: new ExpressionFilterDefinition<AppIncomingEventPayloadEntity>(
          xx => xx.AppIncomingEventObjectId == x.AppIncomingEventObjectId && xx.EventPayloadId == x.EventPayloadId),
        update: Builders<AppIncomingEventPayloadEntity>.Update
          .SetOnInsert(xx => xx.AppIncomingEventObjectId, x.AppIncomingEventObjectId)
          .SetOnInsert(xx => xx.ConcurrencyToken, x.ConcurrencyToken)          
          .SetOnInsert(xx => xx.CreatedAt, x.CreatedAt)
          .SetOnInsert(xx => xx.Data, x.Data)
          .SetOnInsert(xx => xx.EntityConcurrencyTokenToDelete, x.EntityConcurrencyTokenToDelete)
          .SetOnInsert(xx => xx.EntityConcurrencyTokenToInsert, x.EntityConcurrencyTokenToInsert)
          .SetOnInsert(xx => xx.EntityId, x.EntityId)
          .SetOnInsert(xx => xx.EntityName, x.EntityName)          
          .SetOnInsert(xx => xx.EventPayloadId, x.EventPayloadId)
          .SetOnInsert(xx => xx.Position, x.Position))
    { IsUpsert = true });

    return Collection.BulkWriteAsync(requests, cancellationToken: cancellationToken);
  }

  /// <inheritdoc/>
  public Task DeleteList(AppIncomingEventPayloadDeleteListCommand command, CancellationToken cancellationToken)
  {
    var filterBuilder = Builders<AppIncomingEventPayloadEntity>.Filter;

    var filter = filterBuilder.Empty;

    if (command.ObjectIds?.Count > 0)
    {
      filter = filterBuilder.And(
        filter,
        filterBuilder.Where(x => x.ObjectId != null && command.ObjectIds.Contains(x.ObjectId)));
    }
    
    if (command.AppIncomingEventObjectIds?.Count > 0)
    {
      filter = filterBuilder.And(
        filter,
        filterBuilder.Where(x => command.AppIncomingEventObjectIds.Contains(x.AppIncomingEventObjectId)));
    }

    return Collection.DeleteManyAsync(ClientSessionHandle, filter, cancellationToken: cancellationToken);
  }

  /// <inheritdoc/>
  public Task<long> GetCount(AppIncomingEventPayloadCountQuery query, CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.Filter);

    return Collection.CountDocumentsAsync(ClientSessionHandle, filter, cancellationToken: cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventPayloadEntity>> GetList(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.Filter);

    var found = Collection.Find(ClientSessionHandle, filter)
      .Sort(query.Sort, AppIncomingEventPayloadSettings.DefaultQuerySortSection, CreateSortFieldExpression)
      .TakeMaxCount(query.MaxCount);

    var result = await found.ToListAsync(cancellationToken).ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventPayloadEntity>> GetPageItems(
    AppIncomingEventPayloadPageQuery query,
    CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.Filter);

    var found = Collection.Find(ClientSessionHandle, filter)
      .Sort(query.Sort, AppIncomingEventPayloadSettings.DefaultQuerySortSection, CreateSortFieldExpression)
      .TakePage(query.Page);

    var result = await found.ToListAsync(cancellationToken).ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventPayloadEntity?> GetSingle(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken)
  {
    if (query.ObjectId == null)
    {
      return null;
    }

    var filter = Builders<AppIncomingEventPayloadEntity>.Filter.Eq(x => x.ObjectId, query.ObjectId);

    var task = Collection.Find(ClientSessionHandle, filter).FirstOrDefaultAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  protected sealed override Expression<Func<AppIncomingEventPayloadEntity, bool>> CreateFilterByPrimaryKey(
    string? primaryKey)
  {
    return x => x.ObjectId == primaryKey;
  }

  private static FilterDefinition<AppIncomingEventPayloadEntity> CreateFilter(
    AppIncomingEventPayloadQueryFilterSection? filterSection)
  {
    var filterBuilder = Builders<AppIncomingEventPayloadEntity>.Filter;

    var result = Builders<AppIncomingEventPayloadEntity>.Filter.Empty;

    if (!string.IsNullOrEmpty(filterSection?.FullTextSearchQuery))
    {
      Regex re = new($".*{filterSection.FullTextSearchQuery}.*", RegexOptions.IgnoreCase);

      result = filterBuilder.Or(
        filterBuilder.Regex(x => x.EntityId, re),
        filterBuilder.Regex(x => x.EntityName, re));
    }

    if (!string.IsNullOrEmpty(filterSection?.AppIncomingEventObjectId))
    {
      result = filterBuilder.And(
        result,
        filterBuilder.Where(x => x.AppIncomingEventObjectId == filterSection.AppIncomingEventObjectId));
    }

    return result;
  }
  
  private static Expression<Func<AppIncomingEventPayloadEntity, object?>> CreateSortFieldExpression(string field)
  {
    Expression<Func<AppIncomingEventPayloadEntity, object?>> result;

    if (field.EqualsToSortField(AppIncomingEventPayloadSettings.SortFieldForObjectId))
    {
      result = x => x.ObjectId;
    }
    else if (field.EqualsToSortField(AppIncomingEventPayloadSettings.SortFieldForAppIncomingEventObjectId))
    {
      result = x => x.AppIncomingEventObjectId;
    }
    else if (field.EqualsToSortField(AppIncomingEventPayloadSettings.SortFieldForData))
    {
      result = x => x.Data;
    }
    else if (field.EqualsToSortField(AppIncomingEventPayloadSettings.SortFieldForEntityConcurrencyTokenToDelete))
    {
      result = x => x.EntityConcurrencyTokenToDelete;
    }
    else if (field.EqualsToSortField(AppIncomingEventPayloadSettings.SortFieldForEntityConcurrencyTokenToInsert))
    {
      result = x => x.EntityConcurrencyTokenToInsert;
    }
    else if (field.EqualsToSortField(AppIncomingEventPayloadSettings.SortFieldForEntityId))
    {
      result = x => x.EntityId;
    }
    else if (field.EqualsToSortField(AppIncomingEventPayloadSettings.SortFieldForEntityName))
    {
      result = x => x.EntityName;
    }
    else if (field.EqualsToSortField(AppIncomingEventPayloadSettings.SortFieldForPosition))
    {
      result = x => x.Position;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }
}

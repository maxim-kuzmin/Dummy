namespace Makc.Dummy.Reader.Infrastructure.MongoDB.AppIncomingEventPayload;

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
    database.GetCollection<AppIncomingEventPayloadEntity>(appDbSettings.Entities.AppIncomingEvent.Collection)),
  IAppIncomingEventPayloadRepository
{
  /// <inheritdoc/>
  public Task<long> CountAsync(AppIncomingEventPayloadPageQuery query, CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.Filter);

    return Collection.CountDocumentsAsync(ClientSessionHandle, filter, cancellationToken: cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventPayloadEntity?> GetAsync(
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
  public async Task<List<AppIncomingEventPayloadEntity>> ListAsync(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.PageQuery.Filter);

    var found = Collection.Find(ClientSessionHandle, filter)
      .TakePage(query.PageQuery.Page)
      .Sort(query.Sort, AppIncomingEventSettings.DefaultQuerySortSection, CreateSortFieldExpression);

    var result = await found.ToListAsync(cancellationToken).ConfigureAwait(false);

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
    var builder = Builders<AppIncomingEventPayloadEntity>.Filter;

    var result = Builders<AppIncomingEventPayloadEntity>.Filter.Empty;

    if (!string.IsNullOrEmpty(filterSection?.FullTextSearchQuery))
    {
      Regex re = new($".*{filterSection.FullTextSearchQuery}.*", RegexOptions.IgnoreCase);

      result = builder.Or(builder.Regex(x => x.EntityId, re), builder.Regex(x => x.EntityName, re));
    }

    return result;
  }
  
  private static Expression<Func<AppIncomingEventPayloadEntity, object>> CreateSortFieldExpression(string field)
  {
    Expression<Func<AppIncomingEventPayloadEntity, object>> result;

    if (field.EqualsToSortField(AppIncomingEventSettings.SortFieldForId))
    {
      result = x => x.EntityId;
    }
    else if (field.EqualsToSortField(AppIncomingEventSettings.SortFieldForName))
    {
      result = x => x.EntityName;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }
}

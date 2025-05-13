namespace Makc.Dummy.Reader.Infrastructure.MongoDB.AppIncomingEvent;

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
  public Task<long> GetCount(AppIncomingEventPageQuery query, CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.Filter);

    return Collection.CountDocumentsAsync(ClientSessionHandle, filter, cancellationToken: cancellationToken);
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
  public async Task<List<AppIncomingEventEntity>> GetList(
    AppIncomingEventListQuery query,
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
  protected sealed override Expression<Func<AppIncomingEventEntity, bool>> CreateFilterByPrimaryKey(
    string? primaryKey)
  {
    return x => x.ObjectId == primaryKey;
  }

  private static FilterDefinition<AppIncomingEventEntity> CreateFilter(
    AppIncomingEventQueryFilterSection? filterSection)
  {
    var builder = Builders<AppIncomingEventEntity>.Filter;

    var result = Builders<AppIncomingEventEntity>.Filter.Empty;

    if (!string.IsNullOrEmpty(filterSection?.FullTextSearchQuery))
    {
      Regex re = new($".*{filterSection.FullTextSearchQuery}.*", RegexOptions.IgnoreCase);

      result = builder.Or(builder.Regex(x => x.EventId, re), builder.Regex(x => x.EventName, re));
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
}

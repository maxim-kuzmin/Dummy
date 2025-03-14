namespace Makc.Dummy.Reader.Infrastructure.MongoDB.DummyItem.Entity;

/// <summary>
/// Репозиторий сущности фиктивного предмета.
/// </summary>
/// <param name="appDbSettings">Настройки базы данных приложения.</param>
/// <param name="clientSessionHandle">Описатель сессии клиента.</param>
/// <param name="database">База данных.</param>
public class DummyItemEntityRepository(
  AppDbSettings appDbSettings,
  IClientSessionHandle clientSessionHandle,
  IMongoDatabase database) :
  EntityRepository<DummyItemEntity>(
    clientSessionHandle,
    database.GetCollection<DummyItemEntity>(appDbSettings.Entities.DummyItem.Collection)),
  IDummyItemEntityRepository
{
  /// <inheritdoc/>
  public Task<long> CountAsync(DummyItemPageQuery query, CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.Filter);

    return Collection.CountDocumentsAsync(ClientSessionHandle, filter, cancellationToken: cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<DummyItemEntity?> GetAsync(DummyItemSingleQuery query, CancellationToken cancellationToken)
  {
    if (query.ObjectId == null)
    {
      return null;
    }

    var filter = Builders<DummyItemEntity>.Filter.Eq(x => x.ObjectId, query.ObjectId);

    var task = Collection.Find(ClientSessionHandle, filter).FirstOrDefaultAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<List<DummyItemEntity>> ListAsync(DummyItemListQuery query, CancellationToken cancellationToken)
  {
    var filter = CreateFilter(query.PageQuery.Filter);
    
    var found = Collection.Find(ClientSessionHandle, filter);

    var sort = query.Sort ?? DummyItemSettings.DefaultQuerySortSection;

    Expression<Func<DummyItemEntity, object>> field;

    if (sort.Field.EqualsToSortField(DummyItemSettings.SortFieldForId))
    {
      field = x => x.Id;
    }
    else
    {
      throw new NotImplementedException();
    }

    var page = query.PageQuery.Page;

    if (page != null)
    {
      if (page.Number > 0)
      {
        found = found.Skip((page.Number - 1) * page.Size);
      }

      if (page.Size > 0)
      {
        found = found.Limit(page.Size);
      }
    }

    found = sort.IsDesc ? found.SortByDescending(field) : found.SortBy(field);

    var result = await found.ToListAsync(cancellationToken).ConfigureAwait(false);

    return result;
  }

  private static FilterDefinition<DummyItemEntity> CreateFilter(DummyItemQueryFilterSection? filterSection)
  {
    var builder = Builders<DummyItemEntity>.Filter;

    var result = Builders<DummyItemEntity>.Filter.Empty;

    if (!string.IsNullOrEmpty(filterSection?.FullTextSearchQuery))
    {
      Regex re = new($".*{filterSection.FullTextSearchQuery}.*", RegexOptions.IgnoreCase);

      result = builder.Or(builder.Regex(x => x.Id.ToString(), re), builder.Regex(x => x.Name, re));
    }

    return result;
  }
}

﻿namespace Makc.Dummy.Reader.Infrastructure.MongoDB.DummyItem.Entity;

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

    var found = Collection.Find(ClientSessionHandle, filter)
      .TakePage(query.PageQuery.Page)
      .Sort(query.Sort, DummyItemSettings.DefaultQuerySortSection, CreateSortFieldExpression);

    var result = await found.ToListAsync(cancellationToken).ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  protected sealed override Expression<Func<DummyItemEntity, bool>> CreateFilterByPrimaryKey(string? primaryKey)
  {
    return x => x.ObjectId == primaryKey;
  }

  private static FilterDefinition<DummyItemEntity> CreateFilter(DummyItemQueryFilterSection? filterSection)
  {
    var builder = Builders<DummyItemEntity>.Filter;

    var result = Builders<DummyItemEntity>.Filter.Empty;

    if (!string.IsNullOrEmpty(filterSection?.FullTextSearchQuery))
    {
      Regex re = new($".*{filterSection.FullTextSearchQuery}.*", RegexOptions.IgnoreCase);

      result = builder.Or(builder.Regex(x => x.IdAsString, re), builder.Regex(x => x.Name, re));
    }

    return result;
  }
  
  private static Expression<Func<DummyItemEntity, object>> CreateSortFieldExpression(string field)
  {
    Expression<Func<DummyItemEntity, object>> result;

    if (field.EqualsToSortField(DummyItemSettings.SortFieldForId))
    {
      result = x => x.Id;
    }
    else if (field.EqualsToSortField(DummyItemSettings.SortFieldForName))
    {
      result = x => x.Name;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }
}

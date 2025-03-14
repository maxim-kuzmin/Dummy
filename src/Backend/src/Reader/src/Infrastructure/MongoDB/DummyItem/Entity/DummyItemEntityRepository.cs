namespace Makc.Dummy.Reader.Infrastructure.MongoDB.DummyItem.Entity;

/// <summary>
/// Репозиторий сущности фиктивного предмета.
/// </summary>
/// <param name="clientSessionHandle">Описатель сессии клиента.</param>
/// <param name="database">База данных.</param>
public class DummyItemEntityRepository(
  IClientSessionHandle clientSessionHandle,
  IMongoDatabase database) :
  EntityRepository<DummyItemEntity>(
    clientSessionHandle,
    database.GetCollection<DummyItemEntity>(DummyItemSettings.CollectionName)),
  IDummyItemEntityRepository
{
  /// <inheritdoc/>
  public Task<long> CountAsync(DummyItemPageQuery query, CancellationToken cancellationToken)
  {
    var filter = Builders<DummyItemEntity>.Filter.Empty;

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
    var filter = Builders<DummyItemEntity>.Filter.Empty;

    var task = Collection.Find(ClientSessionHandle, filter).ToListAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }
}

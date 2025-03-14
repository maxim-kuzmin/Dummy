namespace Makc.Dummy.Shared.Infrastructure.MongoDB.Entity;

/// <summary>
/// Репозиторий сущности.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <param name="_clientSessionHandle">Описатель сессии клиента.</param>
/// <param name="_collection">Коллекция.</param>
public class EntityRepository<TEntity>(
  IClientSessionHandle _clientSessionHandle,
  IMongoCollection<TEntity> _collection
  ) : IEntityRepository<TEntity> where TEntity: EntityBaseWithObjectIdAsStringPrimaryKey
{
  /// <summary>
  /// Коллекция.
  /// </summary>
  protected virtual IMongoCollection<TEntity> Collection => _collection;

  /// <inheritdoc/>
  public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
  {
    var task = Collection.InsertOneAsync(_clientSessionHandle, entity, cancellationToken: cancellationToken);

    await task.ConfigureAwait(false);

    return entity;
  }

  /// <inheritdoc/>
  public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
  {
    var task = Collection.DeleteOneAsync(
      _clientSessionHandle,
      x => x.ObjectId == entity.ObjectId,
      cancellationToken: cancellationToken);

    await task.ConfigureAwait(false);
  }

  /// <inheritdoc/>
  public async Task<TEntity?> GetByObjectIdAsync(string objectId, CancellationToken cancellationToken)
  {
    var task = Collection.Find(_clientSessionHandle, x => x.ObjectId == objectId)
      .FirstOrDefaultAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
  {
    var task = Collection.ReplaceOneAsync(
      _clientSessionHandle,
      x => x.ObjectId == entity.ObjectId,
      entity,
      cancellationToken: cancellationToken);

    await task.ConfigureAwait(false);
  }
}

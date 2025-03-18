namespace Makc.Dummy.Shared.Infrastructure.MongoDB.Entity;

/// <summary>
/// Репозиторий сущности.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <param name="clientSessionHandle">Описатель сессии клиента.</param>
/// <param name="collection">Коллекция.</param>
public class EntityRepository<TEntity>(
  IClientSessionHandle clientSessionHandle,
  IMongoCollection<TEntity> collection) :
  IEntityRepository<TEntity>
  where TEntity : EntityBaseWithStringPrimaryKey
{
  /// <summary>
  /// Описатель сессии клиента.
  /// </summary>
  protected IClientSessionHandle ClientSessionHandle { get; } = clientSessionHandle;

  /// <summary>
  /// Коллекция.
  /// </summary>
  protected IMongoCollection<TEntity> Collection { get; } = collection;

  /// <inheritdoc/>
  public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
  {
    var task = Collection.InsertOneAsync(ClientSessionHandle, entity, cancellationToken: cancellationToken);

    await task.ConfigureAwait(false);

    return entity;
  }

  /// <inheritdoc/>
  public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
  {
    var task = Collection.DeleteOneAsync(
      ClientSessionHandle,
      x => x.GetPrimaryKey() == entity.GetPrimaryKey(),
      cancellationToken: cancellationToken);

    await task.ConfigureAwait(false);
  }

  /// <inheritdoc/>
  public async Task<TEntity?> GetByObjectIdAsync(string objectId, CancellationToken cancellationToken)
  {
    var task = Collection.Find(ClientSessionHandle, x => x.GetPrimaryKey() == objectId)
      .FirstOrDefaultAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
  {
    var task = Collection.ReplaceOneAsync(
      ClientSessionHandle,
      x => x.GetPrimaryKey() == entity.GetPrimaryKey(),
      entity,
      cancellationToken: cancellationToken);

    await task.ConfigureAwait(false);
  }
}

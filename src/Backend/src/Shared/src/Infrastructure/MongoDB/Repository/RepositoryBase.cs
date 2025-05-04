namespace Makc.Dummy.Shared.Infrastructure.MongoDB.Repository;

/// <summary>
/// Основа репозитория.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <param name="clientSessionHandle">Описатель сессии клиента.</param>
/// <param name="collection">Коллекция.</param>
public abstract class RepositoryBase<TEntity>(
  IClientSessionHandle clientSessionHandle,
  IMongoCollection<TEntity> collection) :
  IObjectRepository<TEntity>
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
    var filter = CreateFilterByPrimaryKey(entity.GetPrimaryKey());

    var task = Collection.DeleteOneAsync(ClientSessionHandle, filter, cancellationToken: cancellationToken);

    await task.ConfigureAwait(false);
  }

  /// <inheritdoc/>
  public async Task<TEntity?> GetByObjectIdAsync(string objectId, CancellationToken cancellationToken)
  {
    var filter = CreateFilterByPrimaryKey(objectId);

    var task = Collection.Find(ClientSessionHandle, filter).FirstOrDefaultAsync(cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
  {
    var filter = CreateFilterByPrimaryKey(entity.GetPrimaryKey());

    var task = Collection.ReplaceOneAsync(ClientSessionHandle, filter, entity, cancellationToken: cancellationToken);

    await task.ConfigureAwait(false);
  }

  protected abstract Expression<Func<TEntity, bool>> CreateFilterByPrimaryKey(string? primaryKey);
}

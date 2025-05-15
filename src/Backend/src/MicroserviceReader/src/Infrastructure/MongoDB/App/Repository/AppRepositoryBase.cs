namespace Makc.Dummy.MicroserviceReader.Infrastructure.MongoDB.App.Repository;

/// <summary>
/// Основа репозитория приложения.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <param name="clientSessionHandle">Описатель сессии клиента.</param>
/// <param name="collection">Коллекция.</param>
public abstract class AppRepositoryBase<TEntity>(
  IClientSessionHandle clientSessionHandle,
  IMongoCollection<TEntity> collection) :
  RepositoryBase<TEntity>(clientSessionHandle, collection)
  where TEntity : EntityBaseWithStringPrimaryKey
{
}

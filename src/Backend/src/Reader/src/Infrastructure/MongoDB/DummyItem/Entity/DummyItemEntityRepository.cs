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
}

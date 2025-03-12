
namespace Makc.Dummy.Reader.Infrastructure.MongoDB.DummyItem;

/// <summary>
/// Репозиторий фиктивного предмета.
/// </summary>
public class DummyItemRepository : IDummyItemRepository
{
  public Task<DummyItemEntity> AddAsync(DummyItemEntity entity, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(DummyItemEntity entity, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<DummyItemEntity> GetByObjectIdAsync(string objectId, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task UpdateAsync(DummyItemEntity entity, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}

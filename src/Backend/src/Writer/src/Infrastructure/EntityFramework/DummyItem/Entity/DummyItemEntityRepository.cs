namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.DummyItem.Entity;

/// <summary>
/// Репозиторий сущности фиктивного предмета.
/// </summary>
public class DummyItemEntityRepository(AppDbContext dbContext) :
  AppRepositoryBase<DummyItemEntity>(dbContext),
  IDummyItemEntityRepository
{
}

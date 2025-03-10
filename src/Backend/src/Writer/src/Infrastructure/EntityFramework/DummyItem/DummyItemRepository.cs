namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.DummyItem;

/// <summary>
/// Репозиторий фиктивного предмета.
/// </summary>
public class DummyItemRepository(AppDbContext dbContext) :
  AppRepositoryBase<DummyItemEntity>(dbContext),
  IDummyItemRepository
{
}

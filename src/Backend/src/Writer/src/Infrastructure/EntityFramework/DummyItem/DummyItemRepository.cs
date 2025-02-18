namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.DummyItem;

public class DummyItemRepository(AppDbContext dbContext) :
  AppRepositoryBase<DummyItemEntity>(dbContext),
  IDummyItemRepository
{
}

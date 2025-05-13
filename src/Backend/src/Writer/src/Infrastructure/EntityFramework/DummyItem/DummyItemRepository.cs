namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.DummyItem;

/// <summary>
/// Репозиторий фиктивного предмета.
/// </summary>
/// <param name="appDbContext">Контекст базы данных приложения.</param>
public class DummyItemRepository(AppDbContext appDbContext) :
  AppRepositoryBase<DummyItemEntity>(appDbContext),
  IDummyItemRepository
{
}

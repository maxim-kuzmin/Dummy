namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppEvent.Entity;

/// <summary>
/// Репозиторий события приложения.
/// </summary>
public class AppEventEntityRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppEventEntity>(dbContext),
  IAppEventEntityRepository
{
}

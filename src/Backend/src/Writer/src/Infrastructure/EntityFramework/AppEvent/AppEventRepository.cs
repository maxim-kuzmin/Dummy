namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppEvent;

/// <summary>
/// Репозиторий события приложения.
/// </summary>
public class AppEventRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppEventEntity>(dbContext),
  IAppEventRepository
{
}

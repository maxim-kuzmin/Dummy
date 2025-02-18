namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppEvent;

public class AppEventRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppEventEntity>(dbContext),
  IAppEventRepository
{
}

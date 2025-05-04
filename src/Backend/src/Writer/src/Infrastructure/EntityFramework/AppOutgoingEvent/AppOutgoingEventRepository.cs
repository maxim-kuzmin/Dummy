namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppOutgoingEvent;

/// <summary>
/// Репозиторий исходящего события приложения.
/// </summary>
public class AppOutgoingEventRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppOutgoingEventEntity>(dbContext),
  IAppOutgoingEventRepository
{
}

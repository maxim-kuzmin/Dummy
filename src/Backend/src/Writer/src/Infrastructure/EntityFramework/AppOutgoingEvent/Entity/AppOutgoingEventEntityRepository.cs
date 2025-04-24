namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppOutgoingEvent.Entity;

/// <summary>
/// Репозиторий исходящего события приложения.
/// </summary>
public class AppOutgoingEventEntityRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppOutgoingEventEntity>(dbContext),
  IAppOutgoingEventEntityRepository
{
}

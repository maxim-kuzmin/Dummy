namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppOutgoingEventPayload;

/// <summary>
/// Репозиторий полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppOutgoingEventPayloadEntity>(dbContext),
  IAppOutgoingEventPayloadRepository
{
}

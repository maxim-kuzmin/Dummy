namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppEventPayload;

/// <summary>
/// Репозиторий полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppEventPayloadEntity>(dbContext),
  IAppEventPayloadEntityRepository
{
}

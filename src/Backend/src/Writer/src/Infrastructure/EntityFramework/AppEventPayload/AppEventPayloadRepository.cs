namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppEventPayload;

public class AppEventPayloadRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppEventPayloadEntity>(dbContext),
  IAppEventPayloadRepository
{
}

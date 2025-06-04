namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.EntityFramework.AppOutgoingEventPayload;

/// <summary>
/// Репозиторий полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="appDbContext">Контекст базы данных приложения.</param>
public class AppOutgoingEventPayloadRepository(AppDbContext appDbContext) :
  AppRepositoryBase<AppOutgoingEventPayloadEntity>(appDbContext),
  IAppOutgoingEventPayloadRepository
{
}

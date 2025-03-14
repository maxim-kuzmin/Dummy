namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Entity;

/// <summary>
/// Интерфейс репозитория сущности полезной нагрузки события приложения.
/// </summary>
public interface IAppEventPayloadEntityRepository : IReadRepository<AppEventPayloadEntity>,
  IRepository<AppEventPayloadEntity>
{
}

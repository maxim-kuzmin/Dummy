namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Entity;

/// <summary>
/// Интерфейс репозитория сущности полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadEntityRepository : IReadRepository<AppOutgoingEventPayloadEntity>,
  IRepository<AppOutgoingEventPayloadEntity>
{
}

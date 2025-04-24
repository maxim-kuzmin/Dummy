namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Entity;

/// <summary>
/// Интерфейс репозитория сущности исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventEntityRepository : IReadRepository<AppOutgoingEventEntity>,
  IRepository<AppOutgoingEventEntity>
{
}

namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent;

/// <summary>
/// Интерфейс репозитория исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventRepository : IReadRepository<AppOutgoingEventEntity>,
  IRepository<AppOutgoingEventEntity>
{
}

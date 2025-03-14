namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Entity;

/// <summary>
/// Интерфейс репозитория сущности события приложения.
/// </summary>
public interface IAppEventEntityRepository : IReadRepository<AppEventEntity>,
  IRepository<AppEventEntity>
{
}

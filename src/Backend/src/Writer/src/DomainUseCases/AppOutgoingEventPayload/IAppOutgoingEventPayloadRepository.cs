namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload;

/// <summary>
/// Интерфейс репозитория полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadRepository : IReadRepository<AppOutgoingEventPayloadEntity>,
  IRepository<AppOutgoingEventPayloadEntity>
{
}

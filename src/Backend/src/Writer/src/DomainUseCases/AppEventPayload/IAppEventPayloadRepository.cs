namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload;

/// <summary>
/// Интерфейс репозитория полезной нагрузки события приложения.
/// </summary>
public interface IAppEventPayloadRepository : IReadRepository<AppEventPayloadEntity>,
  IRepository<AppEventPayloadEntity>
{
}

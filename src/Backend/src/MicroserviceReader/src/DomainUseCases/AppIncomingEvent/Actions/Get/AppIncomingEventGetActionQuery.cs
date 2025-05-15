namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Actions.Get;

/// <summary>
/// Запрос действия по получению входящего события приложения.
/// </summary>
public record AppIncomingEventGetActionQuery : AppIncomingEventSingleQuery, IQuery<Result<AppIncomingEventSingleDTO>>;

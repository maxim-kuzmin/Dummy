namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Get;

/// <summary>
/// Запрос действия по получению исходящего события приложения.
/// </summary>
public record AppOutgoingEventGetActionQuery : AppOutgoingEventSingleQuery, IQuery<Result<AppOutgoingEventSingleDTO>>;

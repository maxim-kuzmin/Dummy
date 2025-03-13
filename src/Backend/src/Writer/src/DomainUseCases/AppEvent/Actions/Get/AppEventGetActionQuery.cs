namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;

/// <summary>
/// Запрос действия по получению события приложения.
/// </summary>
public record AppEventGetActionQuery : AppEventSingleQuery, IQuery<Result<AppEventSingleDTO>>;

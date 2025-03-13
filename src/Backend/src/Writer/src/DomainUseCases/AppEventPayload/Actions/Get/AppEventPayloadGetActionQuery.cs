namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;

/// <summary>
/// Запрос действия по получению полезной нагрузки события приложения.
/// </summary>
public record AppEventPayloadGetActionQuery : AppEventPayloadSingleQuery, IQuery<Result<AppEventPayloadSingleDTO>>;

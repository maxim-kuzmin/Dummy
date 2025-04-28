namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Get;

/// <summary>
/// Запрос действия по получению полезной нагрузки исходящего события приложения.
/// </summary>
public record AppOutgoingEventPayloadGetActionQuery :
  AppOutgoingEventPayloadSingleQuery,
  IQuery<Result<AppOutgoingEventPayloadSingleDTO>>;

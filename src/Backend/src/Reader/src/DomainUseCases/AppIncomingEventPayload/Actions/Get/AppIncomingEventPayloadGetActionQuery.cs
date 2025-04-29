namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Get;

/// <summary>
/// Запрос действия по получению полезной нагрузки входящего события приложения.
/// </summary>
public record AppIncomingEventPayloadGetActionQuery :
  AppIncomingEventPayloadSingleQuery,
  IQuery<Result<AppIncomingEventPayloadSingleDTO>>;

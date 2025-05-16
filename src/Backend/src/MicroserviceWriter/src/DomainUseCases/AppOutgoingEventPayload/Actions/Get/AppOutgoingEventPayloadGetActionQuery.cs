namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Actions.Get;

/// <summary>
/// Запрос действия по получению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventPayloadGetActionQuery(long Id) :
  AppOutgoingEventPayloadSingleQuery(Id),
  IQuery<Result<AppOutgoingEventPayloadSingleDTO>>;

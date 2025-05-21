namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Actions.Get;

/// <summary>
/// Запрос действия по получению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventPayloadGetActionRequest(AppOutgoingEventPayloadSingleQuery Query) :
  IQuery<Result<AppOutgoingEventPayloadSingleDTO>>;

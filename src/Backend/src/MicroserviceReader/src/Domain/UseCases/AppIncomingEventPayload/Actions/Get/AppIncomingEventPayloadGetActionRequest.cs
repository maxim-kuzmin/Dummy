namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Actions.Get;

/// <summary>
/// Запрос действия по получению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppIncomingEventPayloadGetActionRequest(AppIncomingEventPayloadSingleQuery Query) :
  IQuery<Result<AppIncomingEventPayloadSingleDTO>>;

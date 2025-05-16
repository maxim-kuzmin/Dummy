namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Actions.Get;

/// <summary>
/// Запрос действия по получению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventPayloadGetActionQuery(string? ObjectId) :
  AppIncomingEventPayloadSingleQuery(ObjectId),
  IQuery<Result<AppIncomingEventPayloadSingleDTO>>;

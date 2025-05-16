namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Actions.Get;

/// <summary>
/// Запрос действия по получению входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventGetActionQuery(string? ObjectId) :
  AppIncomingEventSingleQuery(ObjectId),
  IQuery<Result<AppIncomingEventSingleDTO>>;

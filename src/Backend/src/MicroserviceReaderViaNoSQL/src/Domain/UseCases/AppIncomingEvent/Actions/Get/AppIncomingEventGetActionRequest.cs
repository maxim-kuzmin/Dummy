namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.Get;

/// <summary>
/// Запрос действия по получению входящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppIncomingEventGetActionRequest(AppIncomingEventSingleQuery Query) :
  IQuery<Result<AppIncomingEventSingleDTO>>;

namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Actions.Get;

/// <summary>
/// Запрос действия по получению исходящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventGetActionRequest(AppOutgoingEventSingleQuery Query) :
  IQuery<Result<AppOutgoingEventSingleDTO>>;

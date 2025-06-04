namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка исходящих событий приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventGetListActionRequest(AppOutgoingEventListQuery Query) :
  IQuery<Result<List<AppOutgoingEventSingleDTO>>>;

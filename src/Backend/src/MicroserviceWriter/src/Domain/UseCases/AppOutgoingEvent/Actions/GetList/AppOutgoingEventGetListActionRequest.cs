namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка исходящих событий приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventGetListActionRequest(AppOutgoingEventPageQuery Query) :  
  IQuery<Result<AppOutgoingEventListDTO>>;

namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка исходящих событий приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppOutgoingEventGetListActionQuery(AppOutgoingEventPageQuery PageQuery) :
  AppOutgoingEventListQuery(PageQuery),
  IQuery<Result<AppOutgoingEventListDTO>>;

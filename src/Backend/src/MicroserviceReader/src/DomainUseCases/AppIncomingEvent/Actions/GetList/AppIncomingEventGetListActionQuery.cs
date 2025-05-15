namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка входящих событий приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppIncomingEventGetListActionQuery(AppIncomingEventPageQuery PageQuery) :
  AppIncomingEventListQuery(PageQuery),
  IQuery<Result<AppIncomingEventListDTO>>;

namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка событий приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppEventGetListActionQuery(AppEventPageQuery PageQuery) :
  AppEventListQuery(PageQuery),
  IQuery<Result<AppEventListDTO>>;

namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка событий приложения.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Filter">Фильтр.</param>
public record AppEventGetListActionQuery(
  QueryPageSection? Page,
  AppEventGetListActionQueryFilter? Filter) : IQuery<Result<AppEventListDTO>>;

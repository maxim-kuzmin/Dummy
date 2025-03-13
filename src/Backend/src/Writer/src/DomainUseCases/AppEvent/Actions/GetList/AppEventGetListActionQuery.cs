namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка событий приложения.
/// </summary>
/// <param name="CountQuery">Запрос количества.</param>
public record AppEventGetListActionQuery(AppEventPageQuery CountQuery) :
  AppEventListQuery(CountQuery),
  IQuery<Result<AppEventListDTO>>;

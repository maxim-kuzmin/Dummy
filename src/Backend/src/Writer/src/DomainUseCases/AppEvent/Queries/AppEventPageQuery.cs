namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Queries;

/// <summary>
/// Запрос страницы событий приложения.
/// </summary>
public record AppEventPageQuery : PageQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public AppEventQueryFilterSection? Filter { get; set; }
}

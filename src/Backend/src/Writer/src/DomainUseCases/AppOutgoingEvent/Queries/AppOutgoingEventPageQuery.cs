namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Queries;

/// <summary>
/// Запрос страницы исходящих событий приложения.
/// </summary>
public record AppOutgoingEventPageQuery : PageQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public AppOutgoingEventQueryFilterSection? Filter { get; set; }
}

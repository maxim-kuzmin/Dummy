namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос страницы входящих событий приложения.
/// </summary>
public record AppIncomingEventPageQuery : PageQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public AppIncomingEventQueryFilterSection? Filter { get; set; }
}

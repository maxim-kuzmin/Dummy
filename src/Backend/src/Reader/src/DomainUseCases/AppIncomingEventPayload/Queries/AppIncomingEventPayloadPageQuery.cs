namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос страницы полезных нагрузок входящего события приложения.
/// </summary>
public record AppIncomingEventPayloadPageQuery : PageQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public AppIncomingEventPayloadQueryFilterSection? Filter { get; set; }         
}

namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Queries;

/// <summary>
/// Запрос страницы полезных нагрузок исходящего события приложения.
/// </summary>
public record AppOutgoingEventPayloadPageQuery : PageQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public AppOutgoingEventPayloadQueryFilterSection? Filter { get; set; }         
}

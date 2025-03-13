namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Queries;

/// <summary>
/// Запрос страницы полезных нагрузок события приложения.
/// </summary>
public record AppEventPayloadPageQuery : PageQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public AppEventPayloadQueryFilterSection? Filter { get; set; }         
}

namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Queries;

/// <summary>
/// Запрос количества полезных нагрузок события приложения.
/// </summary>
public record AppEventPayloadCountQuery : CountQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public AppEventPayloadQueryFilterSection? Filter { get; set; }         
}

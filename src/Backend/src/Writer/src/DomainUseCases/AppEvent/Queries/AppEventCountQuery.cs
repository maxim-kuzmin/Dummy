namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Queries;

/// <summary>
/// Запрос количества событий приложения.
/// </summary>
public record AppEventCountQuery : CountQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public AppEventQueryFilterSection? Filter { get; set; }
}

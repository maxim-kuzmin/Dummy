namespace Makc.Dummy.Shared.DomainUseCases.Queries;

/// <summary>
/// Запрос страницы.
/// </summary>
public record PageQuery
{
  /// <summary>
  /// Страница.
  /// </summary>
  public QueryPageSection? Page { get; set; }
}

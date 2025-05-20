namespace Makc.Dummy.Shared.Domain.UseCases.Queries;

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

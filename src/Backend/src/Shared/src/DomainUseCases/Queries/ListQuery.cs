namespace Makc.Dummy.Shared.DomainUseCases.Queries;

/// <summary>
/// Запрос списка.
/// </summary>
public record ListQuery
{
  /// <summary>
  /// Сортировка.
  /// </summary>
  public QuerySortSection? Sort { get; set; }
}

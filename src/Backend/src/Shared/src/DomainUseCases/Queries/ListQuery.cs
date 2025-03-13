namespace Makc.Dummy.Shared.DomainUseCases.Queries;

/// <summary>
/// Запрос списка.
/// </summary>
public record ListQuery
{
  /// <summary>
  /// Порядок.
  /// </summary>
  public QueryOrderSection? Order { get; set; }
}

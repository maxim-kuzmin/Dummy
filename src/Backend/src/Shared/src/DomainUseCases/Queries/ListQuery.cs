namespace Makc.Dummy.Shared.DomainUseCases.Queries;

/// <summary>
/// Запрос списка.
/// </summary>
public record ListQuery : CountQuery
{
  /// <summary>
  /// Порядок.
  /// </summary>
  public QueryOrderSection? Order { get; set; }
}

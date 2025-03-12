namespace Makc.Dummy.Shared.DomainUseCases.Queries;

/// <summary>
/// Запрос количества.
/// </summary>
public record CountQuery
{
  /// <summary>
  /// Страница.
  /// </summary>
  public QueryPageSection? Page { get; set; }
}

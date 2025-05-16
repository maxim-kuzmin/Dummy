namespace Makc.Dummy.Gateway.DomainUseCasesForMicroserviceWriter.DummyItem.Queries;

/// <summary>
/// Запрос страницы фиктивных предметов.
/// </summary>
public record DummyItemPageQuery : PageQuery
{
  /// <summary>
  /// Фильтр.
  /// </summary>
  public DummyItemQueryFilterSection? Filter { get; set; }
}

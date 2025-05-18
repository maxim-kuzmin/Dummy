namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem.Queries;

/// <summary>
/// Запрос количества фиктивных предметов.
/// </summary>
/// <param name="Filter">Фильтр.</param>
public record DummyItemCountQuery(
  DummyItemQueryFilterSection? Filter);

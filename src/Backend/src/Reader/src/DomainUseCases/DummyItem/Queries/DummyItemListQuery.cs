namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Queries;

/// <summary>
/// Запрос списка фиктивных предметов.
/// </summary>
/// <param name="CountQuery">Запрос количества.</param>
public record DummyItemListQuery(DummyItemCountQuery CountQuery) : ListQuery
{
}

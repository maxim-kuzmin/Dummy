namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Queries;

/// <summary>
/// Запрос списка фиктивных предметов.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record DummyItemListQuery(DummyItemPageQuery PageQuery) : ListQuery
{
}

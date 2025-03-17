namespace Makc.Dummy.Gateway.DomainUseCasesForReader.DummyItem.Actions.GetList.Query;

/// <summary>
/// Фильтр запроса действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record DummyItemGetListActionQueryFilter(string? FullTextSearchQuery);

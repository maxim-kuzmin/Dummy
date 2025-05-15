namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem;

/// <summary>
/// Интерфейс репозитория фиктивного предмета.
/// </summary>
public interface IDummyItemRepository : IReadRepository<DummyItemEntity>, IRepository<DummyItemEntity>
{
}

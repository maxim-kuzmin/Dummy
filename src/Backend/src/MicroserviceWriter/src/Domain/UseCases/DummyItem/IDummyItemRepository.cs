namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.DummyItem;

/// <summary>
/// Интерфейс репозитория фиктивного предмета.
/// </summary>
public interface IDummyItemRepository : IReadRepository<DummyItemEntity>, IRepository<DummyItemEntity>
{
}

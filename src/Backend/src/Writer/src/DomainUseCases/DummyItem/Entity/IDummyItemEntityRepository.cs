namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Entity;

/// <summary>
/// Интерфейс репозитория сущности фиктивного предмета.
/// </summary>
public interface IDummyItemEntityRepository : IReadRepository<DummyItemEntity>, IRepository<DummyItemEntity>
{
}

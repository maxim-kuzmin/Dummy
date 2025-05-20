namespace Makc.Dummy.MicroserviceReader.Domain.Model.DummyItem;

/// <summary>
/// Интерфейс фабрики фиктивного предмета.
/// </summary>
public interface IDummyItemFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityToChange">Сущность для изменения.</param>
  /// <returns>Агрегат.</returns>
  DummyItemAggregate CreateAggregate(DummyItemEntity? entityToChange = null);
}

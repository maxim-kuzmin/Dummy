namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных единственного фиктивного предмета.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных.</returns>
  public static DummyItemSingleDTO ToDummyItemSingleDTO(this DummyItemEntity entity)
  {
    return new(
      ObjectId: entity.ObjectId,
      Id: entity.Id,
      Name: entity.Name,
      ConcurrencyToken: entity.ConcurrencyToken);
  }
}

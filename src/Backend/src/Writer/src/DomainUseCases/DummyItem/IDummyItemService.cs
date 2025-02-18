namespace Makc.Dummy.Writer.DomainUseCases.DummyItem;

/// <summary>
/// Интерфейс сервиса фиктивного предмета.
/// </summary>
public interface IDummyItemService
{
  /// <summary>
  /// Обработчик изменения сущности.
  /// </summary>
  /// <param name="entityChange">Изменение сущности.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> OnEntityChanged(EntityChange<DummyItemEntity> entityChange, CancellationToken cancellationToken);
}

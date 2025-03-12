namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Services;

/// <summary>
/// Интерфейс сервиса команд фиктивного предмета.
/// </summary>
public interface IDummyItemCommandService
{
  /// <summary>
  /// Обработчик изменения сущности.
  /// </summary>
  /// <param name="entityChange">Изменение сущности.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> OnEntityChanged(EntityChange<DummyItemEntity> entityChange, CancellationToken cancellationToken);
}

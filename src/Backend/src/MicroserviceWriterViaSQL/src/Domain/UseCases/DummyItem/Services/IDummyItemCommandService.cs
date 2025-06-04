namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.DummyItem.Services;

/// <summary>
/// Интерфейс сервиса команд фиктивного предмета.
/// </summary>
public interface IDummyItemCommandService
{
  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithoutValue> Delete(
    DummyItemDeleteCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Обработчик изменения сущности.
  /// </summary>
  /// <param name="payloads">Полезные нагрузки.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithoutValue> OnEntityChanged(
    IEnumerable<AppEventPayloadWithDataAsDictionary> payloads,
    CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithValue<DummyItemSingleDTO>> Save(
    DummyItemSaveCommand command,
    CancellationToken cancellationToken);
}

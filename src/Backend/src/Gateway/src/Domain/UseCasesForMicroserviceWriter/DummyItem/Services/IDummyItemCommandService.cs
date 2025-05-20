namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceWriter.DummyItem.Services;

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
  Task<Result> Delete(DummyItemDeleteCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<DummyItemSingleDTO>> Save(DummyItemSaveCommand command, CancellationToken cancellationToken);
}

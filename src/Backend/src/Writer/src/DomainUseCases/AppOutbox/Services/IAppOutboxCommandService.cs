namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Services;

/// <summary>
/// Сервис исходящего сообщения приложения.
/// </summary>
public interface IAppOutboxCommandService
{
  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithoutValue> Save(AppOutboxSaveActionCommand command, CancellationToken cancellationToken);
}

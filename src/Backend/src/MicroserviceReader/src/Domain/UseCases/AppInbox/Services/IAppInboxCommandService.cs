namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Services;

/// <summary>
/// Интерфейс сервиса входящих сообщений приложения.
/// </summary>
public interface IAppInboxCommandService
{
  /// <summary>
  /// Потребить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Consume(AppInboxConsumeCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Загрузить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Load(AppInboxLoadCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Обработать.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Process(AppInboxProcessCommand command, CancellationToken cancellationToken);
}

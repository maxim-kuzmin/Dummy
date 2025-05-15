namespace Makc.Dummy.Reader.DomainUseCases.AppInbox.Services;

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
  Task<Result> Consume(AppInboxConsumeActionCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Загрузить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Load(AppInboxLoadActionCommand request, CancellationToken cancellationToken);
}

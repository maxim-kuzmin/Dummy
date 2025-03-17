namespace Makc.Dummy.Gateway.DomainUseCasesForReader.App.Services;

/// <summary>
/// Интерфейс сервиса команд приложения.
/// </summary>
public interface IAppCommandService
{
  /// <summary>
  /// Вход.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand command, CancellationToken cancellationToken);
}

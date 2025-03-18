namespace Makc.Dummy.Gateway.DomainUseCases.Auth.Services;

/// <summary>
/// Интерфейс сервиса команд аутентификации.
/// </summary>
public interface IAuthCommandService
{
  /// <summary>
  /// Вход.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AuthLoginDTO>> Login(AuthLoginActionCommand command, CancellationToken cancellationToken);
}

﻿namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.Auth.Services;

/// <summary>
/// Интерфейс сервиса команд аутентификации. 
/// </summary>
/// <param name="_authOptionsSnapshot">Снимок параметров аутентификации.</param>
public interface IAuthCommandService
{
  /// <summary>
  /// Войти.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AuthLoginDTO>> Login(AuthLoginCommand command, CancellationToken cancellationToken);
}

namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.Auth.Commands;

/// <summary>
/// Команда входа для аутентификации.
/// </summary>
/// <param name="UserName">Имя пользователя.</param>
/// <param name="Password">Пароль.</param>
public record AuthLoginCommand(
  string UserName,
  string Password);

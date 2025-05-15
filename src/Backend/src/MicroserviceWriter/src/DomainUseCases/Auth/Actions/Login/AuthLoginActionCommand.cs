namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.Auth.Actions.Login;

/// <summary>
/// Команда действия по входу для аутентификации.
/// </summary>
/// <param name="UserName">Имя пользователя.</param>
/// <param name="Password">Пароль.</param>
public record AuthLoginActionCommand(
  string UserName,
  string Password) : ICommand<Result<AuthLoginDTO>>;

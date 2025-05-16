namespace Makc.Dummy.Gateway.DomainUseCases.Auth.Actions.Login;

/// <summary>
/// Команда действия по входу.
/// </summary>
/// <param name="UserName">Имя пользователя.</param>
/// <param name="Password">Пароль.</param>
public record AuthLoginActionCommand(
  string UserName,
  string Password) : ICommand<Result<AuthLoginDTO>>;

namespace Makc.Dummy.Gateway.DomainUseCasesForWriter.App.Actions.Login;

/// <summary>
/// Команда действия по входу в приложение.
/// </summary>
/// <param name="UserName">Имя пользователя.</param>
/// <param name="Password">Пароль.</param>
public record AppLoginActionCommand(
  string UserName,
  string Password) : ICommand<Result<AppLoginActionDTO>>;

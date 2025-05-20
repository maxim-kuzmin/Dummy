namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceWriter.Auth.Actions.Login;

/// <summary>
/// Запрос действия по входу для аутентификации.
/// </summary>
/// <param name="Command">Команда.</param>
public record AuthLoginActionRequest(AuthLoginCommand Command) : ICommand<Result<AuthLoginDTO>>;

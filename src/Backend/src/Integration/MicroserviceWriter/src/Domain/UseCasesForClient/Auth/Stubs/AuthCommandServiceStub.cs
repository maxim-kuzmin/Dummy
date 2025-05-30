namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCasesForClient.Auth.Stubs;

/// <summary>
/// Заглушка сервиса команд аутентификации.
/// </summary>
public class AuthCommandServiceStub : IAuthCommandService
{
  /// <inheritdoc/>
  public Task<Result<AuthLoginDTO>> Login(AuthLoginCommand command, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}

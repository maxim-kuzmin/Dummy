namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.Auth.Stubs;

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

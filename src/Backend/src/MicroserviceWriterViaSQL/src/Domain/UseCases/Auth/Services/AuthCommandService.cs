namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.Auth.Services;

/// <summary>
/// Сервис команд аутентификации. 
/// </summary>
/// <param name="_authOptionsSnapshot">Снимок параметров аутентификации.</param>
public class AuthCommandService(
  IOptionsSnapshot<AppConfigOptionsDomainAuthSection> _authOptionsSnapshot) : IAuthCommandService
{
  /// <inheritdoc/>
  public Task<Result<AuthLoginDTO>> Login(AuthLoginCommand command, CancellationToken cancellationToken)
  {
    var authOptions = _authOptionsSnapshot.Value;

    var accessToken = authOptions.CreateAccessToken(command.UserName, null);

    AuthLoginDTO result = new()
    {
      UserName = command.UserName,
      AccessToken = accessToken ?? string.Empty,
    };

    return Task.FromResult(Result.Success(result));
  }
}

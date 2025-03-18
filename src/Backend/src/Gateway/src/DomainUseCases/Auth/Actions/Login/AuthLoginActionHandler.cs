namespace Makc.Dummy.Gateway.DomainUseCases.Auth.Actions.Login;

/// <summary>
/// Обработчик действия по входу для аутентификации.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AuthLoginActionHandler(
  IAuthCommandService _service) :
  ICommandHandler<AuthLoginActionCommand, Result<AuthLoginDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AuthLoginDTO>> Handle(AuthLoginActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Login(request, cancellationToken);
  }
}

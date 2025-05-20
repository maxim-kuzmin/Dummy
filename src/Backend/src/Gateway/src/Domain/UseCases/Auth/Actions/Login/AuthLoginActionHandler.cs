namespace Makc.Dummy.Gateway.Domain.UseCases.Auth.Actions.Login;

/// <summary>
/// Обработчик действия по входу.
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

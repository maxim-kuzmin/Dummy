namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.Auth.Actions.Login;

/// <summary>
/// Обработчик действия по входу для аутентификации.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AuthLoginActionHandler(IAuthCommandService _service) :
  ICommandHandler<AuthLoginActionRequest, Result<AuthLoginDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AuthLoginDTO>> Handle(AuthLoginActionRequest request, CancellationToken cancellationToken)
  {
    return _service.Login(request.Command, cancellationToken);
  }
}

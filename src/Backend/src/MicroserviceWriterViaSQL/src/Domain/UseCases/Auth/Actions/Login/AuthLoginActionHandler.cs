namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.Auth.Actions.Login;

/// <summary>
/// Обработчик действия по входу для аутентификации.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AuthLoginActionHandler(IAuthCommandService _service) :
  IRequestHandler<AuthLoginActionRequest, Result<AuthLoginDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AuthLoginDTO>> Handle(AuthLoginActionRequest request, CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AuthLoginDTO>>(_service.Login(request.Command, cancellationToken));
  }
}

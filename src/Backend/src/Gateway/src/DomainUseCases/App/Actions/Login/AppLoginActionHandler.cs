namespace Makc.Dummy.Gateway.DomainUseCases.App.Actions.Login;

/// <summary>
/// Обработчик действия по входу в приложение.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppLoginActionHandler(
  IAppCommandService _service) :
  ICommandHandler<AppLoginActionCommand, Result<AppLoginDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppLoginDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Login(request, cancellationToken);
  }
}

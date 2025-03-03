namespace Makc.Dummy.Writer.DomainUseCases.App.Actions.Login;

/// <summary>
/// Обработчик действия по входу в приложение.
/// </summary>
/// <param name="_appConfigOptionsAuthenticationSectionSnapshot">
/// Снимок раздела аутентификации в параметрах конфигурации приложения.
/// </param>
public class AppLoginActionHandler(
  IOptionsSnapshot<AppConfigOptionsAuthenticationSection> _appConfigOptionsAuthenticationSectionSnapshot) :
  ICommandHandler<AppLoginActionCommand, Result<AppLoginActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppLoginActionDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    var appConfigOptionsAuthenticationSection = _appConfigOptionsAuthenticationSectionSnapshot.Value;

    var accessToken = appConfigOptionsAuthenticationSection.CreateAccessToken(request.UserName, null);

    var dto = new AppLoginActionDTO(request.UserName, accessToken ?? string.Empty);

    return Task.FromResult(Result.Success(dto));
  }
}

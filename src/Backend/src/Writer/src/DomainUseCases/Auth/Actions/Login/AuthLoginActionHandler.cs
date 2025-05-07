using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Domain;

namespace Makc.Dummy.Writer.DomainUseCases.Auth.Actions.Login;

/// <summary>
/// Обработчик действия по входу для аутентификации.
/// </summary>
/// <param name="_appConfigOptionsAuthenticationSectionSnapshot">
/// Снимок раздела аутентификации в параметрах конфигурации приложения.
/// </param>
public class AuthLoginActionHandler(
  IOptionsSnapshot<AppConfigOptionsDomainAuthSection> _appConfigOptionsAuthenticationSectionSnapshot) :
  ICommandHandler<AuthLoginActionCommand, Result<AuthLoginDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AuthLoginDTO>> Handle(AuthLoginActionCommand request, CancellationToken cancellationToken)
  {
    var appConfigOptionsAuthenticationSection = _appConfigOptionsAuthenticationSectionSnapshot.Value;

    var accessToken = appConfigOptionsAuthenticationSection.CreateAccessToken(request.UserName, null);

    var dto = new AuthLoginDTO(request.UserName, accessToken ?? string.Empty);

    return Task.FromResult(Result.Success(dto));
  }
}

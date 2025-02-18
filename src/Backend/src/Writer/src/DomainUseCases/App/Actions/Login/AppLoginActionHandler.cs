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

    var claims = new List<Claim>
    {
      new(ClaimTypes.Name, request.UserName)
    };

    var issuerSigningKey = appConfigOptionsAuthenticationSection.GetSymmetricSecurityKey();

    var signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);

    var expires = DateTime.UtcNow.Add(TimeSpan.FromDays(1));

    var token = new JwtSecurityToken(
      issuer: appConfigOptionsAuthenticationSection.Issuer,
      audience: appConfigOptionsAuthenticationSection.Audience,
      claims: claims,
      expires: expires,
      signingCredentials: signingCredentials);

    var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

    var dto = new AppLoginActionDTO(request.UserName, accessToken);

    return Task.FromResult(Result.Success(dto));
  }
}

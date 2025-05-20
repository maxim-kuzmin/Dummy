namespace Makc.Dummy.Gateway.Infrastructure.HttpForMicroserviceWriter.Auth;

/// <summary>
/// Настройки аутентификации.
/// </summary>
public class AuthSettings
{
  /// <summary>
  /// Корень.
  /// </summary>
  public const string Root = "auth";

  /// <summary>
  /// URL действия по входу.
  /// </summary>
  public const string LoginActionUrl = $"{Root}/login";
}

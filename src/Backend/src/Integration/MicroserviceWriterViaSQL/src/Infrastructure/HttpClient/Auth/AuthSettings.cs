namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpClient.Auth;

/// <summary>
/// Настройки аутентификации.
/// </summary>
public class AuthSettings
{
  /// <summary>
  /// Корень.
  /// </summary>
  public const string Root = $"{AppSettings.Root}/auth";

  /// <summary>
  /// URL действия по входу.
  /// </summary>
  public const string LoginActionUrl = $"{Root}/login";
}

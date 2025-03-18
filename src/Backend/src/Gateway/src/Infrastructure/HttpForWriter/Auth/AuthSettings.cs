namespace Makc.Dummy.Gateway.Infrastructure.HttpForWriter.Auth;

/// <summary>
/// Настройки приложения.
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

  /// <summary>
  /// Имя клиента HTTP.
  /// </summary>
  public const string HttpClientName = "Writer";
}

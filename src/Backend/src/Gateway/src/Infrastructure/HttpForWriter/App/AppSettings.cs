namespace Makc.Dummy.Gateway.Infrastructure.HttpForWriter.App;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
  /// <summary>
  /// Корень.
  /// </summary>
  public const string Root = "app";

  /// <summary>
  /// URL действия по входу.
  /// </summary>
  public const string LoginActionUrl = $"{Root}/login";

  /// <summary>
  /// Имя клиента HTTP.
  /// </summary>
  public const string HttpClientName = "Writer";
}

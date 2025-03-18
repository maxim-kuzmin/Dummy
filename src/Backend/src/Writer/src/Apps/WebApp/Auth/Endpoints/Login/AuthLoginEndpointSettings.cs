using Makc.Dummy.Writer.Apps.WebApp.Auth.Endpoints;

namespace Makc.Dummy.Writer.Apps.WebApp.Auth.Endpoints.Login;

/// <summary>
/// Настройки конечной точки входа в приложение.
/// </summary>
public class AuthLoginEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AuthEndpointsSettings.Root}/login";
}

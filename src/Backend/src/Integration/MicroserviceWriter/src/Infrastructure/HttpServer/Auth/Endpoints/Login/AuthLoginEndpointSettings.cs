namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.Auth.Endpoints.Login;

/// <summary>
/// Настройки конечной точки входа для аутентификации.
/// </summary>
public class AuthLoginEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AuthEndpointsSettings.Root}/login";
}

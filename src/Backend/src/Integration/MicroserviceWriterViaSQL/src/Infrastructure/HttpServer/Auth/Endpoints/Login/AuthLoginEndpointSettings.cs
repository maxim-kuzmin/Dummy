namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.Auth.Endpoints.Login;

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

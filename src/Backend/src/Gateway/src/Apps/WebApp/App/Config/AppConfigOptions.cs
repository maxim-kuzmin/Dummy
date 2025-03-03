namespace Makc.Dummy.Gateway.Apps.WebApp.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public record AppConfigOptions : AppConfigOptionsBase
{
  /// <summary>
  /// Аутентификация.
  /// </summary>
  public AppConfigOptionsAuthenticationSection? Authentication { get; set; }

  /// <summary>
  /// Поставщик OpenID Keycloak.
  /// </summary>
  public AppConfigOptionsKeycloakSection? Keycloak { get; set; }

  /// <summary>
  /// Наблюдаемость.
  /// </summary>
  public AppConfigOptionsObservabilitySection? Observability { get; set; }

  /// <summary>
  /// Писатель.
  /// </summary>
  public AppConfigOptionsWriterSection? Writer { get; set; }
}

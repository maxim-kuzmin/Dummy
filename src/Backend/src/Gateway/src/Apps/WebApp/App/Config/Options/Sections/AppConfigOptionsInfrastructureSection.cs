namespace Makc.Dummy.Gateway.Apps.WebApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureSection
{
  /// <summary>
  /// Поставщик OpenID "Keycloak".
  /// </summary>
  public AppConfigOptionsInfrastructureKeycloakSection? Keycloak { get; set; }

  /// <summary>
  /// Наблюдаемость.
  /// </summary>
  public AppConfigOptionsInfrastructureObservabilitySection? Observability { get; set; }
}

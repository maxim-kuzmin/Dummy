namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure;

/// <summary>
/// Раздел поставщика OpenID "Keycloak" в параметрах конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureKeycloakSection
{
  /// <summary>
  /// Базовый URL.
  /// </summary>
  public string BaseUrl { get; set; } = string.Empty;

  /// <summary>
  /// Идентификатор клиента.
  /// </summary>
  public string ClientId { get; set; } = string.Empty;

  /// <summary>
  /// Секрет клиента.
  /// </summary>
  public string ClientSecret { get; set; } = string.Empty;

  /// <summary>
  /// Область.
  /// </summary>
  public string Realm { get; set; } = string.Empty;
}

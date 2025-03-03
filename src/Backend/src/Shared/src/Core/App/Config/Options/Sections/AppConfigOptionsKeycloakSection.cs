namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections;

/// <summary>
/// Раздел поставщика OpenID Keycloak в параметрах конфигурации приложения.
/// </summary>
public record AppConfigOptionsKeycloakSection
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

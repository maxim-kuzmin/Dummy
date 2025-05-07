namespace Makc.Dummy.Shared.Core.App.Config.Options.Enums;

/// <summary>
/// Перечисление аутентификаций в параметрах конфигурации приложения.
/// </summary>
public enum AppConfigOptionsAuthenticationEnum
{
  /// <summary>
  /// JWT.
  /// </summary>
  JWT = 1,

  /// <summary>
  /// Поставщик OpenID Keycloak.
  /// </summary>
  Keycloak
}

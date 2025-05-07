namespace Makc.Dummy.Gateway.Apps.WebApp.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public record AppConfigOptions : AppConfigOptionsBase
{
  /// <summary>
  /// Предметная область.
  /// </summary>
  public AppConfigOptionsDomainSection? Domain { get; set; }

  /// <summary>
  /// Инфраструктура.
  /// </summary>
  public AppConfigOptionsInfrastructureSection? Infrastructure { get; set; }

  /// <summary>
  /// Интеграция.
  /// </summary>
  public AppConfigOptionsIntegrationSection? Integration { get; set; }
}

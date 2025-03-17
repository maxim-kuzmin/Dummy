namespace Makc.Dummy.Reader.Apps.WebApp.App.Config;

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
  /// База данных MongoDB.
  /// </summary>
  public AppConfigOptionsDbMongoDBSection? MongoDB { get; set; }

  /// <summary>
  /// Наблюдаемость.
  /// </summary>
  public AppConfigOptionsObservabilitySection? Observability { get; set; }
}

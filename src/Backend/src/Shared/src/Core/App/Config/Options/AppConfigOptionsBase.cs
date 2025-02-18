namespace Makc.Dummy.Shared.Core.App.Config.Options;

/// <summary>
/// Основа параметров конфигурации приложения.
/// </summary>
public record AppConfigOptionsBase
{
  /// <summary>
  /// Язык по умолчанию.
  /// </summary>
  public string DefaultLanguage { get; set; } = "ru";

  /// <summary>
  /// Языки.
  /// </summary>
  public string[] Languages { get; set; } = ["ru", "en"];
}

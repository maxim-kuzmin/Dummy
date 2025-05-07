namespace Makc.Dummy.Writer.Apps.WorkerApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainSection
{
  /// <summary>
  /// Приложение.
  /// </summary>
  public AppConfigOptionsDomainAppSection? App { get; set; }

  /// <summary>
  /// База данных приложения.
  /// </summary>
  public AppConfigOptionsDomainAppDbSection? AppDb { get; set; }

  /// <summary>
  /// Исходящие сообщения приложения.
  /// </summary>
  public AppConfigOptionsDomainAppOutboxSection? AppOutbox { get; set; }
}

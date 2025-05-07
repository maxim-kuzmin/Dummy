namespace Makc.Dummy.Reader.Apps.WorkerApp.App.Config.Options.Enums;

/// <summary>
/// Перечисление рабочих нагрузок в параметрах конфигурации приложения.
/// </summary>
public enum AppConfigOptionsWorkloadEnum
{
  /// <summary>
  /// Чистильщик входящих сообщений приложения.
  /// </summary>
  AppInboxCleaner,

  /// <summary>
  /// Потребитель входящих сообщений приложения.
  /// </summary>
  AppInboxConsumer
}

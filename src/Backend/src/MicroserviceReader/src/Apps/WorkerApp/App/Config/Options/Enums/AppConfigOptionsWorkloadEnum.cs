namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.App.Config.Options.Enums;

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
  AppInboxConsumer,

  /// <summary>
  /// Загрузчик входящих сообщений приложения.
  /// </summary>
  AppInboxLoader,
}

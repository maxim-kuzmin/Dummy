namespace Makc.Dummy.MicroserviceWriterViaSQL.Apps.WorkerApp.App.Config.Options.Enums;

/// <summary>
/// Перечисление рабочих нагрузок в параметрах конфигурации приложения.
/// </summary>
public enum AppConfigOptionsWorkloadEnum
{
  /// <summary>
  /// Миграция базы данных приложения.
  /// </summary>
  AppDbMigration,

  /// <summary>
  /// Чистильщик исходящих сообщений приложения.
  /// </summary>
  AppOutboxCleaner,

  /// <summary>
  /// Поставщик исходящих сообщений приложения.
  /// </summary>
  AppOutboxProducer
}

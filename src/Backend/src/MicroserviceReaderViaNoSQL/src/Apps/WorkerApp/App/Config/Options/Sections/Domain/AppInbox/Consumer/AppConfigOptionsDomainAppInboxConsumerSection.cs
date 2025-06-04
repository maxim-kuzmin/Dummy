namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppInbox.Consumer;

/// <summary>
/// Раздел потребителя входящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppInboxConsumerSection
{
  /// <summary>
  /// Имена событий.
  /// </summary>
  public AppEventNameEnum[]? EventNames { get; set; }
}

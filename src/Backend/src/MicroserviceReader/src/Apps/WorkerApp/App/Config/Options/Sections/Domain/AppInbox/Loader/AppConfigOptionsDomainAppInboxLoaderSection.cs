namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppInbox.Loader;

/// <summary>
/// Раздел поставщика исходящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppInboxLoaderSection
{
  /// <summary>
  /// Максимальное количество событий для загрузки.
  /// </summary>
  public int EventMaxCountToLoad { get; set; }

  /// <summary>
  /// Размер страницы полезных нагрузок.
  /// </summary>
  public int PayloadPageSize { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для получения полезных нагрузок.
  /// </summary>
  public int TimeoutInMillisecondsToGetPayloads { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторения.
  /// </summary>
  public int TimeoutInMillisecondsToRepeat { get; set; }
}

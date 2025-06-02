namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppInbox.Loader;

/// <summary>
/// Раздел загрузчика исходящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppInboxLoaderSection
{
  /// <summary>
  /// Максимальное количество событий для загрузки.
  /// </summary>
  public int EventMaxCountToLoad { get; set; }

  /// <summary>
  /// Имена событий.
  /// </summary>
  public AppEventNameEnum[]? EventNames { get; set; }

  /// <summary>
  /// Размер страницы полезных нагрузок.
  /// </summary>
  public int PayloadPageSize { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для получения полезных нагрузок.
  /// </summary>
  public int TimeoutInMillisecondsToGetPayloads { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для старта.
  /// </summary>
  public int TimeoutInMillisecondsToStart { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторения.
  /// </summary>
  public int TimeoutInMillisecondsToRepeat { get; set; }
}

namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure;

/// <summary>
/// Раздел наблюдаемости в параметрах конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureObservabilitySection
{
  /// <summary>
  /// Имя сервиса.
  /// </summary>
  public string ServiceName { get; set; } = string.Empty;

  /// <summary>
  /// Конечная точка gRPC коллектора.
  /// </summary>
  public string CollectorGrpcEndpoint { get; set; } = string.Empty;

  /// <summary>
  /// Конечная точка HTTP REST коллектора.
  /// </summary>
  public string CollectorHttpEndpoint { get; set; } = string.Empty;

  /// <summary>
  /// Признак включения сбора логов.
  /// </summary>
  public bool IsLogsCollectionEnabled { get; set; }

  /// <summary>
  /// Признак включения сбора отслеживания.
  /// </summary>
  public bool IsTracingCollectionEnabled { get; set; }

  /// <summary>
  /// Признак включения сбора измерений.
  /// </summary>
  public bool IsMetricsCollectionEnabled { get; set; }
}

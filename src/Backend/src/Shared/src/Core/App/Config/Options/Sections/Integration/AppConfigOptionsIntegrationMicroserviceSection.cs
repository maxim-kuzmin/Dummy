namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections.Integration;

/// <summary>
/// Раздел микросервиса "Читатель" в параметрах конфигурации интеграции приложения.
/// </summary>
public record AppConfigOptionsIntegrationMicroserviceSection
{
  /// <summary>
  /// Протокол.
  /// </summary>
  public AppConfigOptionsProtocolEnum Protocol { get; set; } = AppConfigOptionsProtocolEnum.Grpc;

  /// <summary>
  /// Конечная точка gRPC.
  /// </summary>
  public string GrpcEndpoint { get; set; } = string.Empty;

  /// <summary>
  /// Конечная точка HTTP REST.
  /// </summary>
  public string HttpEndpoint { get; set; } = string.Empty;
}

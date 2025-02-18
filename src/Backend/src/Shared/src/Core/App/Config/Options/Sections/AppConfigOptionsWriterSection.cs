namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections;

/// <summary>
/// Раздел микросервиса Writer в параметрах конфигурации приложения.
/// </summary>
public record AppConfigOptionsWriterSection
{
  /// <summary>
  /// API.
  /// </summary>
  public AppConfigOptionsAPIEnum API { get; set; } = AppConfigOptionsAPIEnum.Grpc;

  /// <summary>
  /// Адрес gRPC API.
  /// </summary>
  public string GrpcAPIAddress { get; set; } = string.Empty;

  /// <summary>
  /// Адрес HTTP REST API.
  /// </summary>
  public string HttpAPIAddress { get; set; } = string.Empty;
}

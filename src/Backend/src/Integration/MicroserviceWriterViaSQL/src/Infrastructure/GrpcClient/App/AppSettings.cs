namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcClient.App;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
  /// <summary>
  /// Имя клиента gRPC исходящего события приложения.
  /// </summary>
  public const string AppOutgoingEventGrpcClientName = "MicroserviceWriterViaSQLAppOutgoingEvent";

  /// <summary>
  /// Имя клиента gRPC полезной нагрузки исходящего события приложения.
  /// </summary>
  public const string AppOutgoingEventPayloadGrpcClientName = "MicroserviceWriterViaSQLAppOutgoingEventPayload";

  /// <summary>
  /// Имя клиента gRPC приложения.
  /// </summary>
  public const string AuthGrpcClientName = "MicroserviceWriterViaSQLAuth";

  /// <summary>
  /// Имя клиента gRPC фиктивного предмета.
  /// </summary>
  public const string DummyItemGrpcClientName = "MicroserviceWriterViaSQLDummyItem";
}

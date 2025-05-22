namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.App;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
  /// <summary>
  /// Имя клиента gRPC исходящего события приложения.
  /// </summary>
  public const string AppOutgoingEventGrpcClientName = "MicroserviceWriterAppOutgoingEvent";

  /// <summary>
  /// Имя клиента gRPC полезной нагрузки исходящего события приложения.
  /// </summary>
  public const string AppOutgoingEventPayloadGrpcClientName = "MicroserviceWriterAppOutgoingEventPayload";

  /// <summary>
  /// Имя клиента gRPC приложения.
  /// </summary>
  public const string AuthGrpcClientName = "MicroserviceWriterAuth";

  /// <summary>
  /// Имя клиента gRPC фиктивного предмета.
  /// </summary>
  public const string DummyItemGrpcClientName = "MicroserviceWriterDummyItem";
}

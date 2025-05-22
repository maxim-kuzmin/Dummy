namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.App;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
  /// <summary>
  /// Имя клиента gRPC входящего события приложения.
  /// </summary>
  public const string AppIncomingEventGrpcClientName = "MicroserviceReaderAppIncomingEvent";

  /// <summary>
  /// Имя клиента gRPC полезной нагрузки входящего события приложения.
  /// </summary>
  public const string AppIncomingEventPayloadGrpcClientName = "MicroserviceReaderAppIncomingEventPayload";

  /// <summary>
  /// Имя клиента gRPC фиктивного предмета.
  /// </summary>
  public const string DummyItemGrpcClientName = "MicroserviceReaderDummyItem";
}

namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.GrpcClient.App;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
  /// <summary>
  /// Имя клиента gRPC входящего события приложения.
  /// </summary>
  public const string AppIncomingEventGrpcClientName = "MicroserviceReaderViaNoSQLAppIncomingEvent";

  /// <summary>
  /// Имя клиента gRPC полезной нагрузки входящего события приложения.
  /// </summary>
  public const string AppIncomingEventPayloadGrpcClientName = "MicroserviceReaderViaNoSQLAppIncomingEventPayload";

  /// <summary>
  /// Имя клиента gRPC фиктивного предмета.
  /// </summary>
  public const string DummyItemGrpcClientName = "MicroserviceReaderViaNoSQLDummyItem";
}

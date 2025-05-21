namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.App;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
  /// <summary>
  /// Имя клиента gRPC приложения.
  /// </summary>
  public const string AuthGrpcClientName = "MicroserviceWriterAuth";

  /// <summary>
  /// Имя клиента gRPC фиктивного предмета.
  /// </summary>
  public const string DummyItemGrpcClientName = "MicroserviceWriterDummyItem";
}

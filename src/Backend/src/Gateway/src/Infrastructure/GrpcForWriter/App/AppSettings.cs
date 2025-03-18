namespace Makc.Dummy.Gateway.Infrastructure.GrpcForWriter.App;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
  /// <summary>
  /// Имя клиента gRPC приложения.
  /// </summary>
  public const string AppGrpcClientName = "WriterApp";

  /// <summary>
  /// Имя клиента gRPC фиктивного предмета.
  /// </summary>
  public const string DummyItemGrpcClientName = "WriterDummyItem";
}

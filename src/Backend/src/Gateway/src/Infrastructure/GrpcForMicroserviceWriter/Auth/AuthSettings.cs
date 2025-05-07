namespace Makc.Dummy.Gateway.Infrastructure.GrpcForMicroserviceWriter.Auth;

/// <summary>
/// Настройки аутентификации.
/// </summary>
public class AuthSettings
{
  /// <summary>
  /// Имя клиента gRPC приложения.
  /// </summary>
  public const string AuthGrpcClientName = "WriterApp";

  /// <summary>
  /// Имя клиента gRPC фиктивного предмета.
  /// </summary>
  public const string DummyItemGrpcClientName = "WriterDummyItem";
}

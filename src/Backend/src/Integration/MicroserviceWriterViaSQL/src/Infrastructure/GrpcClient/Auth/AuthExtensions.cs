namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcClient.Auth;

/// <summary>
/// Расширения аутентификации.
/// </summary>
public static class AuthExtensions
{
  /// <summary>
  /// Преобразовать к запросу gRPC входа для аутентификации.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос gRPC.</returns>
  public static AuthLoginGrpcRequest ToAuthLoginGrpcRequest(this AuthLoginCommand command)
  {
    return new()
    {
      UserName = command.UserName,
      Password = command.Password,
    };
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных входа для аутентификации.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AuthLoginDTO ToAuthLoginDTO(this AuthLoginGrpcReply reply)
  {
    return new()
    {
      UserName = reply.UserName,
      AccessToken = reply.AccessToken,
    };
  }
}

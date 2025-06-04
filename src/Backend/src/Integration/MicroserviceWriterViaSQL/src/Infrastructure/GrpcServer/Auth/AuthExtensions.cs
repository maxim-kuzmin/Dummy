namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcServer.Auth;

/// <summary>
/// Расширения аутентификации.
/// </summary>
public static class AuthExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по входу в приложение.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по входу в приложение.</returns>
  public static AuthLoginActionRequest ToAuthLoginActionRequest(this AuthLoginGrpcRequest request)
  {
    AuthLoginCommand command = new(request.UserName, request.Password);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к ответу действия по входу в приложение для gRPC.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Ответ действия по входу в приложение для gRPC.</returns>
  public static AuthLoginGrpcReply ToAuthLoginGrpcReply(this AuthLoginDTO dto)
  {
    return new()
    {
      UserName = dto.UserName,
      AccessToken = dto.AccessToken,
    };
  }
}

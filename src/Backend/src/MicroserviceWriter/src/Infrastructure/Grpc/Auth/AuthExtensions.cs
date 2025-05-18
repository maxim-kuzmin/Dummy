namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.Auth;

/// <summary>
/// Расширения аутентификации.
/// </summary>
public static class AuthExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по входу в приложение.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда действия по входу в приложение.</returns>
  public static AuthLoginActionRequest ToAuthLoginActionCommand(this AuthLoginGrpcRequest request)
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

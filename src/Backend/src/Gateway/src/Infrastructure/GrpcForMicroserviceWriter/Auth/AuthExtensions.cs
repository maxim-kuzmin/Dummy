namespace Makc.Dummy.Gateway.Infrastructure.GrpcForMicroserviceWriter.Auth;

/// <summary>
/// Расширения аутентификации.
/// </summary>
public static class AuthExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по входу в приложение.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по входу в приложение.</returns>
  public static AuthLoginActionRequest ToAuthLoginActionRequest(this AuthLoginActionCommand command)
  {
    return new()
    {
      UserName = command.UserName,
      Password = command.Password,
    };
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных входа.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных входа.</returns>
  public static AuthLoginDTO ToAuthLoginDTO(this AuthLoginActionReply reply)
  {
    return new(reply.UserName, reply.AccessToken);
  }
}

namespace Makc.Dummy.Gateway.Infrastructure.GrpcForWriter.Auth;

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
  /// Преобразовать к объекту передачи данных действия по входу в приложение.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных действия по входу в приложение.</returns>
  public static AuthLoginDTO ToAuthLoginActionDTO(this AuthLoginActionReply reply)
  {
    return new(reply.UserName, reply.AccessToken);
  }
}

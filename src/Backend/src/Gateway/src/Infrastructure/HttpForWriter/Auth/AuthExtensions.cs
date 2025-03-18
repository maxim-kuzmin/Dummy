namespace Makc.Dummy.Gateway.Infrastructure.HttpForWriter.Auth;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AuthExtensions
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this AuthLoginActionCommand command)
  {
    return JsonContent.Create(command);
  }
}

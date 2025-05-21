namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpClient.Auth;

/// <summary>
/// Расширения аутентификации.
/// </summary>
public static class AuthExtensions
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this AuthLoginCommand command)
  {
    return JsonContent.Create(command);
  }
}

namespace Makc.Dummy.Gateway.Infrastructure.Http.App.Action.Command;

/// <summary>
/// Расширения команд действия приложения.
/// </summary>
public static class AppActionCommandExtensions
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this AppLoginActionCommand command)
  {
    return JsonContent.Create(command);
  }
}

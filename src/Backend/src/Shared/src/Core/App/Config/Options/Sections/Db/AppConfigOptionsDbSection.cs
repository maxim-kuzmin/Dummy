namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections.Db;

/// <summary>
/// Раздел базы данных в параметрах конфигурации приложения.
/// </summary>
public record AppConfigOptionsDbSection
{
  /// <summary>
  /// Имя строки подключения.
  /// </summary>
  public string ConnectionStringName { get; set; } = string.Empty;

  /// <summary>
  /// База данных.
  /// </summary>
  public string Database { get; set; } = string.Empty;

  /// <summary>
  /// Пароль.
  /// </summary>
  public string Password { get; set; } = string.Empty;

  /// <summary>
  /// Порт.
  /// </summary>
  public int Port { get; set; }

  /// <summary>
  /// Сервер.
  /// </summary>
  public string Server { get; set; } = string.Empty;

  /// <summary>
  /// Идентификатор пользователя.
  /// </summary>
  public string UserId { get; set; } = string.Empty;

  /// <summary>
  /// Преобразовать к строке подключения.
  /// </summary>
  /// <param name="template">Шаблон.</param>
  /// <returns>Строка полключения.</returns>
  public virtual string ToConnectionString(string template)
  {
    return template
      .Replace("{Database}", Database)
      .Replace("{Password}", Password)
      .Replace("{Port}", Port.ToString())
      .Replace("{Server}", Server)
      .Replace("{UserId}", UserId);
  }
}

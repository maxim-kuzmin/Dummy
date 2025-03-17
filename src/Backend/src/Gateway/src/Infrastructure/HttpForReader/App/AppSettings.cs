namespace Makc.Dummy.Gateway.Infrastructure.HttpForReader.App;

/// <summary>
/// Настройки приложения.
/// </summary>
public class AppSettings
{
  /// <summary>
  /// Корень.
  /// </summary>
  public const string Root = "app";

  /// <summary>
  /// URL действия по входу.
  /// </summary>
  public const string LoginActionUrl = $"{Root}/login";

  /// <summary>
  /// Имя клиента фиктивного предмета.
  /// </summary>
  public const string DummyItemClientName = "ReaderDummyItem";
}

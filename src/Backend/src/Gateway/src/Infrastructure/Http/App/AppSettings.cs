﻿namespace Makc.Dummy.Gateway.Infrastructure.Http.App;

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
  /// Имя клиента фиктивного предмета писателя.
  /// </summary>
  public const string WriterDummyItemClientName = "WriterDummyItem";
}

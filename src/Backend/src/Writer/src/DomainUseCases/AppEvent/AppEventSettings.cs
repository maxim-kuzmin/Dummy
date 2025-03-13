﻿namespace Makc.Dummy.Writer.DomainUseCases.AppEvent;

/// <summary>
/// Настройки события приложения.
/// </summary>
public class AppEventSettings
{
  /// <summary>
  /// Поле сортировки для идентификатора.
  /// </summary>
  public const string OrderFieldForId = "Id";

  /// <summary>
  /// Поле сортировки для имени.
  /// </summary>
  public const string OrderFieldForName = "Name";

  /// <summary>
  /// Раздел порядка сортировки по умолчанию в запросе.
  /// </summary>
  public static readonly QueryOrderSection DefaultQueryOrderSection;

  /// <summary>
  /// Конструктор.
  /// </summary>
  static AppEventSettings()
  {
    DefaultQueryOrderSection = new(OrderFieldForId, true);
  }
}

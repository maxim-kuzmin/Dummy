﻿namespace Makc.Dummy.Reader.Apps.WebApp.DummyItem.Endpoints.Update;

/// <summary>
/// Настройки конечной точки обновления фиктивного предмета.
/// </summary>
public class DummyItemUpdateEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{DummyItemEndpointsSettings.Root}/{{objectId}}";
}

﻿namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForWriter.Update;

/// <summary>
/// Настройки конечной точки обновления фиктивного предмета.
/// </summary>
public class DummyItemUpdateEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{DummyItemEndpointsSettings.Root}/{{id:long}}";
}

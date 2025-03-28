﻿namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForWriter.Delete;

/// <summary>
/// Настройки конечной точки удаления фиктивного предмета.
/// </summary>
public class DummyItemDeleteEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{DummyItemEndpointsSettings.Root}/{{id:long}}";
}

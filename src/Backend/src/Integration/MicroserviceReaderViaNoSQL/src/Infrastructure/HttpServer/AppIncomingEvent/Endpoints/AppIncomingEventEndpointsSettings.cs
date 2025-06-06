﻿namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEvent.Endpoints;

/// <summary>
/// Настройки конечных точек входящего события приложения.
/// </summary>
public class AppIncomingEventEndpointsSettings
{
  /// <summary>
  /// Корень.
  /// </summary>
  public const string Root = $"{AppSettings.Root}/app-incoming-events";
}

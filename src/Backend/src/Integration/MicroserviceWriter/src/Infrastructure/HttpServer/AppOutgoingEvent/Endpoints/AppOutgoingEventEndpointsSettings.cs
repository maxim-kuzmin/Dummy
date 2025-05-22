namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints;

/// <summary>
/// Настройки конечных точек исходящего события приложения.
/// </summary>
public class AppOutgoingEventEndpointsSettings
{
  /// <summary>
  /// Корень.
  /// </summary>
  public const string Root = $"{AppSettings.Root}/app-outgoing-events";
}

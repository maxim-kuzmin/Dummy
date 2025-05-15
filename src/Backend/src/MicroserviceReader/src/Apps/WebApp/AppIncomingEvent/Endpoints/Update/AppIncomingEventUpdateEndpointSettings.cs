namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEvent.Endpoints.Update;

/// <summary>
/// Настройки конечной точки обновления входящего события приложения.
/// </summary>
public class AppIncomingEventUpdateEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventEndpointsSettings.Root}/{{objectId}}";
}

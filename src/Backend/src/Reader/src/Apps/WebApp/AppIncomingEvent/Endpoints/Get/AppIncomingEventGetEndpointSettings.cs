namespace Makc.Dummy.Reader.Apps.WebApp.AppIncomingEvent.Endpoints.Get;

/// <summary>
/// Настройки конечной точки получения входящего события приложения.
/// </summary>
public class AppIncomingEventGetEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventEndpointsSettings.Root}/{{objectId}}";
}

namespace Makc.Dummy.Reader.Apps.WebApp.AppIncomingEventPayload.Endpoints.Update;

/// <summary>
/// Настройки конечной точки обновления полезной нагрузки входящего события приложения.
/// </summary>
public class AppIncomingEventPayloadUpdateEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventPayloadEndpointsSettings.Root}/{{objectId}}";
}

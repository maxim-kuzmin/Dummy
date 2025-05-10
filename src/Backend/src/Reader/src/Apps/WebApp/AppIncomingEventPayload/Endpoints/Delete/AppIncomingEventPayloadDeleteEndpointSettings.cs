namespace Makc.Dummy.Reader.Apps.WebApp.AppIncomingEventPayload.Endpoints.Delete;

/// <summary>
/// Настройки конечной точки удаления полезной нагрузки входящего события приложения.
/// </summary>
public class AppIncomingEventPayloadDeleteEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventPayloadEndpointsSettings.Root}/{{objectId}}";
}

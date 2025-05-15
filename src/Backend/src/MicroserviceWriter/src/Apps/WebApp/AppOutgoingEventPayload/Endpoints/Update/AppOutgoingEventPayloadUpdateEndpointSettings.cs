namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEventPayload.Endpoints.Update;

/// <summary>
/// Настройки конечной точки обновления полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadUpdateEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppOutgoingEventPayloadEndpointsSettings.Root}/{{id:long}}";
}

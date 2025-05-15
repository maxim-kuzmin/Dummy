namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEventPayload.Endpoints.Delete;

/// <summary>
/// Настройки конечной точки удаления полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadDeleteEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppOutgoingEventPayloadEndpointsSettings.Root}/{{id:long}}";
}

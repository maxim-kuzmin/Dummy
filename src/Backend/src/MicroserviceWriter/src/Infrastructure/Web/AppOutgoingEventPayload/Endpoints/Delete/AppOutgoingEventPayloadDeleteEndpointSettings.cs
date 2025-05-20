namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Web.AppOutgoingEventPayload.Endpoints.Delete;

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

namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.AppOutgoingEventPayload.Endpoints.Delete;

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

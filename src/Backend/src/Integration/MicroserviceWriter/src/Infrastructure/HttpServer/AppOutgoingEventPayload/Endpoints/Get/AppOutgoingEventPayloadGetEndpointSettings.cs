namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEventPayload.Endpoints.Get;

/// <summary>
/// Настройки конечной точки получения полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadGetEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppOutgoingEventPayloadEndpointsSettings.Root}/{{id:long}}";
}

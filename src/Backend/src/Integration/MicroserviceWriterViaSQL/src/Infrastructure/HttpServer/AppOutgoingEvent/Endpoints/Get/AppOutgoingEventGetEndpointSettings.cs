namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.Get;

/// <summary>
/// Настройки конечной точки получения исходящего события приложения.
/// </summary>
public class AppOutgoingEventGetEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppOutgoingEventEndpointsSettings.Root}/{{id:long}}";
}

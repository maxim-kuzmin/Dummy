namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.Delete;

/// <summary>
/// Настройки конечной точки удаления исходящего события приложения.
/// </summary>
public class AppOutgoingEventDeleteEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppOutgoingEventEndpointsSettings.Root}/{{id:long}}";
}

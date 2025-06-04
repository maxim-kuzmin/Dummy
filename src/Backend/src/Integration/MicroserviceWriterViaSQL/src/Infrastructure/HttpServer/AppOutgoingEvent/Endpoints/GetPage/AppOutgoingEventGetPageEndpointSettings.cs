namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.GetPage;

/// <summary>
/// Настройки конечной точки получения списка исходящих событий приложения.
/// </summary>
public class AppOutgoingEventGetPageEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppOutgoingEventEndpointsSettings.Root}/page/{{CurrentPage}}";
}

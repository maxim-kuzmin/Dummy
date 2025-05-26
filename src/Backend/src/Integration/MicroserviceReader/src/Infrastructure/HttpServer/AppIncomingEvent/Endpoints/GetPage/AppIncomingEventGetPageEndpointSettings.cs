namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.GetPage;

/// <summary>
/// Настройки конечной точки получения списка входящих событий приложения.
/// </summary>
public class AppIncomingEventGetPageEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventEndpointsSettings.Root}/page/{{CurrentPage}}";
}

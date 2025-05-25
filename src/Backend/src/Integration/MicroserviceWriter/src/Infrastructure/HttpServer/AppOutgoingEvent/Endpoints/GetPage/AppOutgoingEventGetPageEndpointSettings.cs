namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.GetPage;

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

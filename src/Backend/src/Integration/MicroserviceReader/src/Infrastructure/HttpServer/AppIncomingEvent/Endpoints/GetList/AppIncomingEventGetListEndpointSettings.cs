namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.GetList;

/// <summary>
/// Настройки конечной точки получения списка входящих событий приложения.
/// </summary>
public class AppIncomingEventGetListEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventEndpointsSettings.Root}";
}

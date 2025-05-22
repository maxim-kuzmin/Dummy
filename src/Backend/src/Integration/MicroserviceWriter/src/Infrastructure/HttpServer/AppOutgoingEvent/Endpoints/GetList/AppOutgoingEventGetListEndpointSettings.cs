namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.GetList;

/// <summary>
/// Настройки конечной точки получения списка исходящих событий приложения.
/// </summary>
public class AppOutgoingEventGetListEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppOutgoingEventEndpointsSettings.Root}";
}

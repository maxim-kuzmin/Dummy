namespace Makc.Dummy.MicroserviceReader.Infrastructure.Web.AppIncomingEvent.Endpoints.Delete;

/// <summary>
/// Настройки конечной точки удаления входящего события приложения.
/// </summary>
public class AppIncomingEventDeleteEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventEndpointsSettings.Root}/{{objectId}}";
}

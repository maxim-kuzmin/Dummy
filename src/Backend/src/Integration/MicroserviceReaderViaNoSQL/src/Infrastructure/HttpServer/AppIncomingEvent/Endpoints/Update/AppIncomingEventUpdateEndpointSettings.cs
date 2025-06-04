namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.Update;

/// <summary>
/// Настройки конечной точки обновления входящего события приложения.
/// </summary>
public class AppIncomingEventUpdateEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventEndpointsSettings.Root}/{{objectId}}";
}

namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.Get;

/// <summary>
/// Настройки конечной точки получения полезной нагрузки входящего события приложения.
/// </summary>
public class AppIncomingEventPayloadGetEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventPayloadEndpointsSettings.Root}/{{objectId}}";
}

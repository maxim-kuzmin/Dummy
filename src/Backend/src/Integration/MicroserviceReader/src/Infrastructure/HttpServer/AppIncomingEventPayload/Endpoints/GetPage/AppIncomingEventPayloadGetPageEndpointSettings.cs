namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.GetPage;

/// <summary>
/// Настройки конечной точки получения списка полезных нагрузок входящего события приложения.
/// </summary>
public class AppIncomingEventPayloadGetPageEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppIncomingEventPayloadEndpointsSettings.Root}/page/{{CurrentPage}}";
}

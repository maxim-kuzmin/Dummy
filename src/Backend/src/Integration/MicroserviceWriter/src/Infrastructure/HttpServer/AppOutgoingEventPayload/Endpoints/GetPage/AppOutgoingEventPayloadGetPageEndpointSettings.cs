namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEventPayload.Endpoints.GetPage;

/// <summary>
/// Настройки конечной точки получения страницы полезных нагрузок исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadGetPageEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppOutgoingEventPayloadEndpointsSettings.Root}/page/{{CurrentPage}}";
}

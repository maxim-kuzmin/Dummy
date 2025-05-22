namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.Update;

/// <summary>
/// Настройки конечной точки обновления исходящего события приложения.
/// </summary>
public class AppOutgoingEventUpdateEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppOutgoingEventEndpointsSettings.Root}/{{id:long}}";
}

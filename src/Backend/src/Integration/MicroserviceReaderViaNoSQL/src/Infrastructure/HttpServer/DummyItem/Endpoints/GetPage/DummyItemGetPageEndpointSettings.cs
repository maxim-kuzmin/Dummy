namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.DummyItem.Endpoints.GetPage;

/// <summary>
/// Настройки конечной точки получения страницы фиктивных предметов.
/// </summary>
public class DummyItemGetPageEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{DummyItemEndpointsSettings.Root}/page/{{CurrentPage}}";
}

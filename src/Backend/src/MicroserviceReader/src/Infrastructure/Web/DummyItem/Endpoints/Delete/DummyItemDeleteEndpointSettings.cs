namespace Makc.Dummy.MicroserviceReader.Infrastructure.Web.DummyItem.Endpoints.Delete;

/// <summary>
/// Настройки конечной точки удаления фиктивного предмета.
/// </summary>
public class DummyItemDeleteEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{DummyItemEndpointsSettings.Root}/{{objectId}}";
}

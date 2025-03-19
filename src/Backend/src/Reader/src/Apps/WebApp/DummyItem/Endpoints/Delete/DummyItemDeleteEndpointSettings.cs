namespace Makc.Dummy.Reader.Apps.WebApp.DummyItem.Endpoints.Delete;

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

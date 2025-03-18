namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForReader.Get;

/// <summary>
/// Настройки конечной точки получения фиктивного предмета.
/// </summary>
public class DummyItemGetEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{DummyItemEndpointsSettings.Root}/{{objectId}}";
}

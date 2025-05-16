namespace Makc.Dummy.Gateway.Apps.WebAppForMicroserviceReader.DummyItem.Endpoints.Get;

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

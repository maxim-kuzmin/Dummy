namespace Makc.Dummy.Writer.Apps.WebApp.DummyItem.Endpoints;

/// <summary>
/// Расширения конечных точек фиктивного предмета.
/// </summary>
public static class DummyItemEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static DummyItemSaveActionCommand ToDummyItemSaveActionCommand(
    this DummyItemCreateEndpointRequest request)
  {
    return new(0, request.Name);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static DummyItemSaveActionCommand ToDummyItemSaveActionCommand(
    this DummyItemUpdateEndpointRequest request)
  {
    return new(request.Id, request.Name);
  }
}

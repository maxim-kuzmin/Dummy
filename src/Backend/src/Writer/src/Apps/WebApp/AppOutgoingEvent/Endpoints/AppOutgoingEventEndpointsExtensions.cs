namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEvent.Endpoints;

/// <summary>
/// Расширения конечных точек исходящего события приложения.
/// </summary>
public static class AppOutgoingEventEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveActionCommand ToAppOutgoingEventSaveActionCommand(
    this AppOutgoingEventCreateEndpointRequest request)
  {
    return new(false, 0, request.Name, request.PublishedAt);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveActionCommand ToAppOutgoingEventSaveActionCommand(
    this AppOutgoingEventUpdateEndpointRequest request)
  {
    return new(true, request.Id, request.Name, request.PublishedAt);
  }
}

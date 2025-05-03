namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEventPayload.Endpoints;

/// <summary>
/// Расширения конечных точек полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionCommand ToAppOutgoingEventPayloadSaveActionCommand(
    this AppOutgoingEventPayloadCreateEndpointRequest request)
  {
    return new(0, request.AppOutgoingEventId, request.Payload);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionCommand ToAppOutgoingEventPayloadSaveActionCommand(
    this AppOutgoingEventPayloadUpdateEndpointRequest request)
  {
    return new(request.Id, request.AppOutgoingEventId, request.Payload);
  }
}

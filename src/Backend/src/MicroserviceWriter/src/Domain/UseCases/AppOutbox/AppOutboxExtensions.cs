namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutbox;

/// <summary>
/// Расширения исходящего сообщения приложения.
/// </summary>
public static class AppOutboxExtensions
{
  /// <summary>
  /// Преобразовать к команде сохранения исходящего сообщения приложения.
  /// </summary>
  /// <param name="appEventName">Имя события приложения.</param>
  /// <param name="payloads">Полезные нагрузки.</param>
  /// <returns>Команда.</returns>
  public static AppOutboxSaveCommand ToAppOutboxSaveCommand(
    this AppEventNameEnum appEventName,
    IEnumerable<AppEventPayloadWithDataAsDictionary> payloads)
  {
    return new(
      EventName: appEventName.ToString(),
      Payloads: [..payloads.Select((x, i) => x.ToAppEventPayloadWithDataAsString(++i))]);
  }

  /// <summary>
  /// Преобразовать к команде сохранения исходящего события приложения.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveCommand ToAppOutgoingEventSaveCommand(this AppOutboxSaveCommand command)
  {
    return new(
      IsUpdate: false,
      Id: 0,
      Data: new(Name: command.EventName, PublishedAt: null));
  }

  /// <summary>
  /// Преобразовать к команде сохранения полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <param name="appOutgoingEventId">Идентификатор исходящего события приложения.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveCommand ToAppOutgoingEventPayloadSaveCommand(
    this AppEventPayloadWithDataAsString payload,
    long appOutgoingEventId)
  {
    return new(
      IsUpdate: false,
      Id: 0,
      Data: new(AppOutgoingEventId: appOutgoingEventId, Payload: payload));
  }
}

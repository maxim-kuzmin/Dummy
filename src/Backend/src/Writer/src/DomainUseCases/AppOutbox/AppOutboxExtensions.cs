namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox;

/// <summary>
/// Расширения исходящего сообщения приложения.
/// </summary>
public static class AppOutboxExtensions
{
  /// <summary>
  /// Преобразовать к команде действия по сохранению исходящего сообщения приложения.
  /// </summary>
  /// <param name="appEventName">Имя события приложения.</param>
  /// <param name="payloads">Полезные нагрузки.</param>
  /// <returns>Команда.</returns>
  public static AppOutboxSaveActionCommand ToAppOutboxSaveActionCommand(
    this AppEventNameEnum appEventName,
    IEnumerable<AppEventPayloadWithDataAsDictionary> payloads)
  {
    return new(appEventName.ToString(), [..payloads.Select((x, i) => x.ToAppEventPayloadWithDataAsString(++i))]);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="command">Команда действия по сохранению исходящего сообщения приложения.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveActionCommand ToAppOutgoingEventSaveActionCommand(
    this AppOutboxSaveActionCommand command)
  {
    return new(false, 0, command.EventName, DateTimeOffset.Now);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <param name="appOutgoingEventId">Идентификатор исходящего события приложения.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionCommand ToAppOutgoingEventPayloadSaveActionCommand(
    this AppEventPayloadWithDataAsString payload,
    long appOutgoingEventId)
  {
    return new(false, 0, appOutgoingEventId, payload);
  }
}

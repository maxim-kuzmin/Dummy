namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutbox.Actions.Save;

/// <summary>
/// Команда действия по сохранению исходящего сообщения приложения.
/// </summary>
/// <param name="EventName">Имя события.</param>
/// <param name="Payloads">Полезные нагрузки.</param>
public record AppOutboxSaveActionCommand(
  string EventName,
  List<AppEventPayloadWithDataAsString> Payloads) : ICommand<Result>;

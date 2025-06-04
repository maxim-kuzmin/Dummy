namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutbox.Commands;

/// <summary>
/// Команда сохранения исходящего сообщения приложения.
/// </summary>
/// <param name="EventName">Имя события.</param>
/// <param name="Payloads">Полезные нагрузки.</param>
public record AppOutboxSaveCommand(
  string EventName,
  List<AppEventPayloadWithDataAsString> Payloads) : ICommand<Result>;

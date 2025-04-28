namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Save;

/// <summary>
/// Команда действия по сохранению в базе данных исходящего события приложения, помеченного как неопубликованное.
/// </summary>
/// <param name="AppEventName">Имя события приложения.</param>
/// <param name="AppEventPayloads">Полезные нагрузки события приложения.</param>
public record AppOutboxSaveActionCommand(
  string AppEventName,
  List<AppEventPayload> AppEventPayloads) : ICommand<Result>;

namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Save;

/// <summary>
/// Команда действия по сохранению в базе данных исходящего события приложения, помеченного как неопубликованное.
/// </summary>
/// <param name="AppOutgoingEventName">Имя исходящего события приложения.</param>
/// <param name="AppOutgoingEventPayloads">Полезные нагрузки исходящего события приложения.</param>
public record AppOutboxSaveActionCommand(
  AppOutgoingEventNameEnum AppOutgoingEventName,
  List<object> AppOutgoingEventPayloads) : ICommand<Result>;

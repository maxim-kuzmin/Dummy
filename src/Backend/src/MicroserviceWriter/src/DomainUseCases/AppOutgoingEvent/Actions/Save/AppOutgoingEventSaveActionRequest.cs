namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Actions.Save;

/// <summary>
/// Запрос действия по сохранению исходящего события приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppOutgoingEventSaveActionRequest(AppOutgoingEventSaveCommand Command) :
  ICommand<Result<AppOutgoingEventSingleDTO>>;

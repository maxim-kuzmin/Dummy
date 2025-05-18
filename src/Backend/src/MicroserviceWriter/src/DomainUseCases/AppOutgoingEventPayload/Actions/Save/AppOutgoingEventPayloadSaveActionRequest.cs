namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Actions.Save;

/// <summary>
/// Запрос действия по сохранению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppOutgoingEventPayloadSaveActionRequest(AppOutgoingEventPayloadSaveCommand Command) :
  ICommand<Result<AppOutgoingEventPayloadSingleDTO>>;

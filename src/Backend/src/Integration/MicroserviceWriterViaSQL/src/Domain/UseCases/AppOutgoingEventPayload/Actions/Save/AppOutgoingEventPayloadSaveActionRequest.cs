namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Actions.Save;

/// <summary>
/// Запрос действия по сохранению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppOutgoingEventPayloadSaveActionRequest(AppOutgoingEventPayloadSaveCommand Command) :
  ICommand<Result<AppOutgoingEventPayloadSingleDTO>>;

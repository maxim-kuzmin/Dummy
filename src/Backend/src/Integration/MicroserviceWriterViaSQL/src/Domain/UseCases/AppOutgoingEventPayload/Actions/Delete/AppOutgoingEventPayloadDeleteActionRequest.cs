namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Actions.Delete;

/// <summary>
/// Запрос действия по удалению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppOutgoingEventPayloadDeleteActionRequest(AppOutgoingEventPayloadDeleteCommand Command) :
  ICommand<Result>;

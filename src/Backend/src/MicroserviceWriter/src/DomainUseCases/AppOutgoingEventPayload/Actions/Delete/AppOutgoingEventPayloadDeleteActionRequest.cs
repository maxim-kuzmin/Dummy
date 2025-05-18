namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Actions.Delete;

/// <summary>
/// Команда действия по удалению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventPayloadDeleteActionRequest(AppOutgoingEventPayloadDeleteCommand Command) :
  ICommand<Result>;

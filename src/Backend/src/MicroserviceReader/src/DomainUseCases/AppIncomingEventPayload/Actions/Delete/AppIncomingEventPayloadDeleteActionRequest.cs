namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Actions.Delete;

/// <summary>
/// Запрос действия по удалению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppIncomingEventPayloadDeleteActionRequest(AppIncomingEventPayloadDeleteCommand Command) :
  ICommand<Result>;

namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Create;

/// <summary>
/// Команда действия по созданию полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="AppIncomingEventId">Идентификатор входящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadCreateActionCommand(
  long AppIncomingEventId,
  AppEventPayload Payload) : ICommand<Result<AppIncomingEventPayloadSingleDTO>>;

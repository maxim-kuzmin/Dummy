namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Update;

/// <summary>
/// Команда действия по обновлению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppIncomingEventId">Идентификатор входящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadUpdateActionCommand(
  long Id,
  long AppIncomingEventId,
  AppEventPayload Payload) : ICommand<Result<AppIncomingEventPayloadSingleDTO>>;

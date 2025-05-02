namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Update;

/// <summary>
/// Команда действия по обновлению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="AppIncomingEventId">Идентификатор входящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadUpdateActionCommand(
  string ObjectId,
  string AppIncomingEventId,
  AppEventPayloadWithDataAsString Payload) : ICommand<Result<AppIncomingEventPayloadSingleDTO>>;

namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Save;

/// <summary>
/// Команда действия по сохранению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="HasEntityBeingSavedAlreadyBeenCreated">Была ли уже создана сохраняемая сущность?</param>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="AppIncomingEventId">Идентификатор входящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadSaveActionCommand(
  bool HasEntityBeingSavedAlreadyBeenCreated,
  string ObjectId,
  string AppIncomingEventId,
  AppEventPayloadWithDataAsString Payload) : ICommand<Result<AppIncomingEventPayloadSingleDTO>>;

namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Save;

/// <summary>
/// Команда действия по сохранению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="HasEntityBeingSavedAlreadyBeenCreated">Была ли уже создана сохраняемая сущность?</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppOutgoingEventPayloadSaveActionCommand(
  bool HasEntityBeingSavedAlreadyBeenCreated,
  long Id,
  long AppOutgoingEventId,
  AppEventPayloadWithDataAsString Payload) : ICommand<Result<AppOutgoingEventPayloadSingleDTO>>;

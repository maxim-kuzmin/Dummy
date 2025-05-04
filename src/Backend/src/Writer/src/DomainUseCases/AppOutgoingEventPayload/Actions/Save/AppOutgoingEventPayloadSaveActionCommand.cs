namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Save;

/// <summary>
/// Команда действия по сохранению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="ShouldEntityBeFoundById">Должна ли сущность быть найдена по идентификатору</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppOutgoingEventPayloadSaveActionCommand(
  bool ShouldEntityBeFoundById,
  long Id,
  long AppOutgoingEventId,
  AppEventPayloadWithDataAsString Payload) : ICommand<Result<AppOutgoingEventPayloadSingleDTO>>;

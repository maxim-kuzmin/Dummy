namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Update;

/// <summary>
/// Команда действия по обновлению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
/// <param name="Data">Данные.</param>
public record AppOutgoingEventPayloadUpdateActionCommand(
  long Id,
  long AppOutgoingEventId,
  string Data) : ICommand<Result<AppOutgoingEventPayloadSingleDTO>>;

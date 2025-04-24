namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Create;

/// <summary>
/// Команда действия по созданию полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
/// <param name="Data">Данные.</param>
public record AppOutgoingEventPayloadCreateActionCommand(
  long AppOutgoingEventId,
  string Data) : ICommand<Result<AppOutgoingEventPayloadSingleDTO>>;

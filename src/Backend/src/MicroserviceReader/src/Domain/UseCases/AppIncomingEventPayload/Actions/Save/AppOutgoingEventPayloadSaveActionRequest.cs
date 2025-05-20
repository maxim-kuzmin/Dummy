namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Actions.Save;

/// <summary>
/// Команда действия по сохранению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppIncomingEventPayloadSaveActionCommand(AppIncomingEventPayloadSaveCommand Command) :
  ICommand<Result<AppIncomingEventPayloadSingleDTO>>;

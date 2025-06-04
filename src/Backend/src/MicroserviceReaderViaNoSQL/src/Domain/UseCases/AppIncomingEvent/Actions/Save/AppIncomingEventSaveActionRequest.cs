namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.Save;

/// <summary>
/// Запрос действия по сохранению входящего события приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppIncomingEventSaveActionRequest(AppIncomingEventSaveCommand Command) :
  ICommand<Result<AppIncomingEventSingleDTO>>;

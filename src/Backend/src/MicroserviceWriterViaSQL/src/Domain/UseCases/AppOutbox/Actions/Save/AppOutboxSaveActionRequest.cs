namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutbox.Actions.Save;

/// <summary>
/// Запрос действия по сохранению исходящего сообщения приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppOutboxSaveActionRequest(AppOutboxSaveCommand Command) : ICommand<Result>;

namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutbox.Actions.Clear;

/// <summary>
/// Запрос действия по очистке исходящих сообщений приложения
/// </summary>
/// <param name="Command">Команда.</param>
public record AppOutboxClearActionRequest(AppOutboxClearCommand Command) : ICommand<Result>;

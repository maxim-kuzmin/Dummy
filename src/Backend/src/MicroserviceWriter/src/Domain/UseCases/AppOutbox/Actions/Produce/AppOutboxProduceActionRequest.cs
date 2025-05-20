namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Запрос действия по выдаче исходящего сообщения приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppOutboxProduceActionRequest(AppOutboxProduceCommand Command) : ICommand<Result>;

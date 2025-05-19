namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Запрос действия по выдаче исходящего сообщения приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppOutboxProduceActionRequest(AppOutboxProduceCommand Command) : ICommand<Result>;

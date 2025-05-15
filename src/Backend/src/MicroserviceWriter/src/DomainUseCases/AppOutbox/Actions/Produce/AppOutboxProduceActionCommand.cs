namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Команда действия по выдаче исходящего сообщения приложения.
/// </summary>
/// <param name="MaxCount">Максимальное количество.</param>
public record AppOutboxProduceActionCommand(int MaxCount) : ICommand<Result>;

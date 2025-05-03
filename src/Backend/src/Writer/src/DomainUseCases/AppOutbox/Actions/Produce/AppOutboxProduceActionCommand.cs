namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Команда действия по выдаче исходящего сообщения приложения.
/// </summary>
public record AppOutboxProduceActionCommand : ICommand<Result>;

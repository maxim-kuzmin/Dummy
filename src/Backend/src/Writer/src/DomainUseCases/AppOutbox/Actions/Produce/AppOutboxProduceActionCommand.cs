namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Команда действия по отправке в очередь сообщений о неопубликованных событиях и пометки их как опубликованные.
/// </summary>
public record AppOutboxProduceActionCommand : ICommand<Result>;

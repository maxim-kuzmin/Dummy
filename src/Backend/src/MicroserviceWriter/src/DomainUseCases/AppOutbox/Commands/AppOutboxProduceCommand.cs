namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutbox.Commands;

/// <summary>
/// Команда выдачи исходящего сообщения приложения.
/// </summary>
/// <param name="MaxCount">Максимальное количество выдаваемых сообщений.</param>
public record AppOutboxProduceCommand(int MaxCount) : ICommand<Result>;

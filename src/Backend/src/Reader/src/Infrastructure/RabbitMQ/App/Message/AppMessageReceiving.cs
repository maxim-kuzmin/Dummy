namespace Makc.Dummy.Reader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Получение сообщения приложения.
/// </summary>
/// <param name="Receiver">Получатель.</param>
/// <param name="Handler">Обработчик.</param>
public record AppMessageReceiving(string Receiver, Func<string, CancellationToken, Task> Handler)
{
}

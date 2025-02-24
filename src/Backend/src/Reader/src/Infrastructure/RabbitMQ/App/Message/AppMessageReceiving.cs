namespace Makc.Dummy.Reader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Получение сообщения приложения.
/// </summary>
/// <param name="Sender">Отправитель.</param>
/// <param name="Handler">Обработчик.</param>
public record AppMessageReceiving(string Sender, Func<string, CancellationToken, Task> Handler)
{
}

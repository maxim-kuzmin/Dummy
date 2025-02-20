namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Интерфейс шины сообщений приложения.
/// </summary>
public interface IAppMessageBus : IMessageBus, IDisposable
{
}

namespace Makc.Dummy.Writer.DomainUseCases.App.Message;

/// <summary>
/// Интерфейс брокера сообщений приложения.
/// </summary>
public interface IAppMessageBroker : IMessageBroker, IAppMessageProducer
{
}

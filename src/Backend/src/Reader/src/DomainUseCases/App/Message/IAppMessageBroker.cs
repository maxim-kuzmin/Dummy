namespace Makc.Dummy.Reader.DomainUseCases.App.Message;

/// <summary>
/// Интерфейс брокера сообщений приложения.
/// </summary>
public interface IAppMessageBroker : IMessageBroker, IAppMessageConsumer
{
}

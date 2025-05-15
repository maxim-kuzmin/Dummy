namespace Makc.Dummy.MicroserviceReader.DomainUseCases.App.Message;

/// <summary>
/// Интерфейс брокера сообщений приложения.
/// </summary>
public interface IAppMessageBroker : IMessageBroker
{
  /// <summary>
  /// Создать потребителя сообщений.
  /// </summary>
  /// <returns>Потребитель сообщений.</returns>
  IAppMessageConsumer CreateMessageConsumer();
}

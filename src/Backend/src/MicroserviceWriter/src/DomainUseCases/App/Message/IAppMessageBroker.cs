namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.App.Message;

/// <summary>
/// Интерфейс брокера сообщений приложения.
/// </summary>
public interface IAppMessageBroker : IMessageBroker
{
  /// <summary>
  /// Создать поставщика сообщений.
  /// </summary>
  /// <returns>Поставщик сообщений.</returns>
  IAppMessageProducer CreateMessageProducer();
}

namespace Makc.Dummy.Shared.Core.Message.Bus;

/// <summary>
/// Интерфейс фабрики шин сообщений.
/// </summary>
public interface IMessageBusFactory : IDisposable
{
  /// <summary>
  /// Создать шину сообщений.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Шина сообщений.</returns>
  Task<IMessageBus> CreateMessageBus(CancellationToken cancellationToken);
}

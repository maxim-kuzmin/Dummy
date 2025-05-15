namespace Makc.Dummy.MicroserviceReader.DomainModel.AppIncomingEvent;

/// <summary>
/// Интерфейс фабрики входящего события приложения.
/// </summary>
public interface IAppIncomingEventFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityToChange">Сущность для изменения.</param>
  /// <returns>Агрегат.</returns>
  AppIncomingEventAggregate CreateAggregate(AppIncomingEventEntity? entityToChange = null);
}

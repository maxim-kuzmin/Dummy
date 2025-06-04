namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.AppOutgoingEvent;

/// <summary>
/// Интерфейс фабрики исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityToChange">Сущность для изменения.</param>
  /// <returns>Агрегат.</returns>
  AppOutgoingEventAggregate CreateAggregate(AppOutgoingEventEntity? entityToChange = null);
}

namespace Makc.Dummy.MicroserviceReader.Domain.Model.AppIncomingEventPayload;

/// <summary>
/// Интерфейс фабрики полезной нагрузки входящего события приложения.
/// </summary>
public interface IAppIncomingEventPayloadFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityToChange">Сущность для изменения.</param>
  /// <returns>Агрегат.</returns>
  AppIncomingEventPayloadAggregate CreateAggregate(AppIncomingEventPayloadEntity? entityToChange = null);
}

namespace Makc.Dummy.MicroserviceWriter.DomainModel.AppOutgoingEventPayload;

/// <summary>
/// Интерфейс фабрики полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityToChange">Сущность для изменения.</param>
  /// <returns>Агрегат.</returns>
  AppOutgoingEventPayloadAggregate CreateAggregate(AppOutgoingEventPayloadEntity? entityToChange = null);
}

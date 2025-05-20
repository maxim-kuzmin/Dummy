namespace Makc.Dummy.MicroserviceWriter.Domain.Model.AppOutgoingEventPayload;

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

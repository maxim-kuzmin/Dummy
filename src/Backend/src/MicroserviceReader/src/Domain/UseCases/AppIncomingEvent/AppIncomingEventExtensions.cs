namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent;

/// <summary>
/// Расширения входящего события приложения.
/// </summary>
public static class AppIncomingEventExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных единственного входящего события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppIncomingEventSingleDTO ToAppIncomingEventSingleDTO(this AppIncomingEventEntity entity)
  {
    return new(
      ObjectId: entity.ObjectId,
      ConcurrencyToken: entity.ConcurrencyToken,
      CreatedAt: entity.CreatedAt,
      EventId: entity.EventId,
      EventName: entity.EventName,
      LastLoadingAt: entity.LastLoadingAt,
      LastLoadingError: entity.LastLoadingError,
      LoadedAt: entity.LoadedAt,
      PayloadCount: entity.PayloadCount,
      PayloadTotalCount: entity.PayloadTotalCount,
      ProcessedAt: entity.ProcessedAt);
  }
}

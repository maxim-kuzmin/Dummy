namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent;

/// <summary>
/// Расширения исходящего события приложения.
/// </summary>
public static class AppOutgoingEventExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных единственного исходящего события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppOutgoingEventSingleDTO ToAppOutgoingEventSingleDTO(this AppOutgoingEventEntity entity)
  {
    return new()
    {
      Id = entity.Id,
      ConcurrencyToken = entity.ConcurrencyToken,
      CreatedAt = entity.CreatedAt,
      Name = entity.Name,
      PublishedAt = entity.PublishedAt,
    };
  }
}

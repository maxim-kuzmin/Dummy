namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос списка незагруженных входящих событий приложения.
/// </summary>
/// <param name="EventName">Имя события.</param>
public record AppIncomingEventUnloadedListQuery(string EventName)
{
  /// <summary>
  /// Идентификаторы объектов.
  /// </summary>
  public List<string> ObjectIds { get; } = [];

  /// <summary>
  /// Максимальное количество.
  /// </summary>
  public int MaxCount { get; set; }
}

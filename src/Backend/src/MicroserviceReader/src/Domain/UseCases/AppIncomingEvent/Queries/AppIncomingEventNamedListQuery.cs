namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос списка именованных входящих событий приложения.
/// </summary>
/// <param name="EventName">Имя события.</param>
public record AppIncomingEventNamedListQuery(string EventName)
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

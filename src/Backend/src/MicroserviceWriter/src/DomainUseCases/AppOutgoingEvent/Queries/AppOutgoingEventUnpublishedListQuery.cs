namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Queries;

/// <summary>
/// Запрос списка неопубликованных исходящих событий приложения.
/// </summary>
public record AppOutgoingEventUnpublishedListQuery
{
  /// <summary>
  /// Идентификаторы.
  /// </summary>
  public List<long> Ids { get; } = [];

  /// <summary>
  /// Максимальное количество.
  /// </summary>
  public int MaxCount { get; set; }
}

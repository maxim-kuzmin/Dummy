namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос единственной полезной нагрузки входящего события приложения.
/// </summary>
public record AppIncomingEventPayloadSingleQuery
{
  /// <summary>
  /// Идентификатор объекта.
  /// </summary>
  public string? ObjectId { get; set; }
}

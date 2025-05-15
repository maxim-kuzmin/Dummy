namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Queries;

/// <summary>
/// Запрос единственной полезной нагрузки исходящего события приложения.
/// </summary>
public record AppOutgoingEventPayloadSingleQuery
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }
}

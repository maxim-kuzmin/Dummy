namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Queries;

/// <summary>
/// Запрос единственной полезной нагрузки события приложения.
/// </summary>
public record AppEventPayloadSingleQuery
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }
}

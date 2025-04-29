namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос единственного входящего события приложения.
/// </summary>
public record AppIncomingEventSingleQuery
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }
}

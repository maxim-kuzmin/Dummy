namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Queries;

/// <summary>
/// Запрос единственного исходящего события приложения.
/// </summary>
public record AppOutgoingEventSingleQuery
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }
}

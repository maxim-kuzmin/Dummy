namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Queries;

/// <summary>
/// Запрос единственного события приложения.
/// </summary>
public record AppEventSingleQuery
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }
}

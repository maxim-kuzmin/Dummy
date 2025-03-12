namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Queries;

/// <summary>
/// Запрос единственного фиктивного предмета.
/// </summary>
public record DummyItemSingleQuery
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }
}

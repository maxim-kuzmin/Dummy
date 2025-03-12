namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Queries;

/// <summary>
/// Запрос единственного фиктивного предмета.
/// </summary>
public record DummyItemSingleQuery
{
  /// <summary>
  /// Идентификатор объекта.
  /// </summary>
  public string? ObjectId { get; set; }
}

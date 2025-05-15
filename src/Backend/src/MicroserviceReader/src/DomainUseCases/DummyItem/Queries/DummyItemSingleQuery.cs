namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Queries;

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

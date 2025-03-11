namespace Makc.Dummy.Reader.DomainModel.DummyItem;

/// <summary>
/// Фабрика фиктивного предмета.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
public class DummyItemFactory(IDummyItemResources _resources) : IDummyItemFactory
{
  /// <inheritdoc/>
  public DummyItemAggregate CreateAggregate(DummyItemEntity? entityToChange = null)
  {
    return new(entityToChange, _resources);
  }
}

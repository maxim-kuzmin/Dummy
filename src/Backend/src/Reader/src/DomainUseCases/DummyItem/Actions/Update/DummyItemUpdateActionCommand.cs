namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Update;

/// <summary>
/// Команда действия по обновлению фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Name">Имя.</param>
public record DummyItemUpdateActionCommand(
  string ObjectId,
  string Name) : ICommand<Result<DummyItemSingleDTO>>;

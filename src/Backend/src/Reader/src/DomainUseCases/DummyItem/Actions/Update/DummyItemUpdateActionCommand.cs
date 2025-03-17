namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Update;

/// <summary>
/// Команда действия по обновлению фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemUpdateActionCommand(
  string ObjectId,
  long Id,
  string Name) : ICommand<Result<DummyItemSingleDTO>>;

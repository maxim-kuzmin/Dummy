namespace Makc.Dummy.Gateway.DomainUseCasesForReader.DummyItem.Actions.Update;

/// <summary>
/// Команда действия по обновлению фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemUpdateActionCommand(
  long Id,
  string Name) : ICommand<Result<DummyItemSingleDTO>>;

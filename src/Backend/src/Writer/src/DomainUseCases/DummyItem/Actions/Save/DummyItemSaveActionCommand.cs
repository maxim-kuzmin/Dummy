namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Save;

/// <summary>
/// Команда действия по сохранению фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemSaveActionCommand(
  long Id,
  string Name) : ICommand<Result<DummyItemSingleDTO>>;

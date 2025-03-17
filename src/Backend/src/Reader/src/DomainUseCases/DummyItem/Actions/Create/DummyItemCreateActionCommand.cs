namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Create;

/// <summary>
/// Команда действия по созданию фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemCreateActionCommand(
  long Id,
  string Name) : ICommand<Result<DummyItemSingleDTO>>;

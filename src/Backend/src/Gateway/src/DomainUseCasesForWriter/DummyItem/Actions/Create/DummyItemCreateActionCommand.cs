namespace Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.Actions.Create;

/// <summary>
/// Команда действия по созданию фиктивного предмета.
/// </summary>
/// <param name="Name">Имя.</param>
public record DummyItemCreateActionCommand(
  string Name) : ICommand<Result<DummyItemSingleDTO>>;

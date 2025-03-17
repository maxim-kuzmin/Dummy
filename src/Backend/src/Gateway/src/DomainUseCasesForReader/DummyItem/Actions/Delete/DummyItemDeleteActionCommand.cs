namespace Makc.Dummy.Gateway.DomainUseCasesForReader.DummyItem.Actions.Delete;

/// <summary>
/// Команда действия по удалению фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record DummyItemDeleteActionCommand(long Id) : ICommand<Result>;

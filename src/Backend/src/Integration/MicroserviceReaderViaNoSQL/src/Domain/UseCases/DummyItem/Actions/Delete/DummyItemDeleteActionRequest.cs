namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Actions.Delete;

/// <summary>
/// Запрос действия по удалению фиктивного предмета.
/// </summary>
/// <param name="Command">Команда.</param>
public record DummyItemDeleteActionRequest(DummyItemDeleteCommand Command) : ICommand<Result>;

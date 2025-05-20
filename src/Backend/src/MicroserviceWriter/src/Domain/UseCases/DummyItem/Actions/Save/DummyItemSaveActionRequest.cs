namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.DummyItem.Actions.Save;

/// <summary>
/// Запрос действия по сохранению фиктивного предмета.
/// </summary>
/// <param name="Command">Команда.</param>
public record DummyItemSaveActionRequest(DummyItemSaveCommand Command) : ICommand<Result<DummyItemSingleDTO>>;

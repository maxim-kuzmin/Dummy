namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem.Actions.Save;

/// <summary>
/// Команда действия по сохранению фиктивного предмета.
/// </summary>
/// <param name="HasEntityBeingSavedAlreadyBeenCreated">Была ли уже создана сохраняемая сущность?</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemSaveActionCommand(
  bool HasEntityBeingSavedAlreadyBeenCreated,
  long Id,
  string Name) : ICommand<Result<DummyItemSingleDTO>>;

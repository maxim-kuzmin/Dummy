namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Actions.Save;

/// <summary>
/// Команда действия по сохранению фиктивного предмета.
/// </summary>
/// <param name="HasEntityBeingSavedAlreadyBeenCreated">Была ли уже создана сохраняемая сущность?</param>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
public record DummyItemSaveActionCommand(
  bool HasEntityBeingSavedAlreadyBeenCreated,
  string ObjectId,
  long Id,
  string Name,
  string ConcurrencyToken) : ICommand<Result<DummyItemSingleDTO>>;

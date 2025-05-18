namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem.Commands;

/// <summary>
/// Команда сохранения фиктивного предмета.
/// </summary>
/// <param name="IsUpdate">Обновление?</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Data">Данные.</param>
public record DummyItemSaveCommand(
  bool IsUpdate,
  long Id,
  DummyItemCommandDataSection Data) : ICommand<Result<DummyItemSingleDTO>>;

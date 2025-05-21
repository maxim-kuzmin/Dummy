namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.DummyItem.Commands;

/// <summary>
/// Команда сохранения фиктивного предмета.
/// </summary>
/// <param name="IsUpdate">Обновление?</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Data">Данные.</param>
public record DummyItemSaveCommand(
  bool IsUpdate,
  long Id,
  DummyItemCommandDataSection Data);

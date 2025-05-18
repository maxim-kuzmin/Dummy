namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Commands;

/// <summary>
/// Команда сохранения исходящего события приложения.
/// </summary>
/// <param name="IsUpdate">Обновление?</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Data">Данные.</param>
public record AppOutgoingEventSaveCommand(
  bool IsUpdate,
  long Id,
  AppOutgoingEventCommandDataSection Data);

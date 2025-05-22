namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Commands;

/// <summary>
/// Команда сохранения входящего события приложения.
/// </summary>
/// <param name="IsUpdate">Обновление?</param>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Data">Данные.</param>
public record AppIncomingEventSaveCommand(
  bool IsUpdate,
  string ObjectId,
  AppIncomingEventCommandDataSection Data);

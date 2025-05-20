namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Commands;

/// <summary>
/// Команда сохранения полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="IsUpdate">Обновление?</param>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Data">Данные.</param>
public record AppIncomingEventPayloadSaveCommand(
  bool IsUpdate,
  string ObjectId,
  AppIncomingEventPayloadCommandDataSection Data);

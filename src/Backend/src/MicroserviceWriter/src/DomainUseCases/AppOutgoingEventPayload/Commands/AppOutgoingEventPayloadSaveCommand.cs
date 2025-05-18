namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Commands;

/// <summary>
/// Команда сохранения полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="IsUpdate">Обновление?</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Data">Данные.</param>
public record AppOutgoingEventPayloadSaveCommand(
  bool IsUpdate,
  long Id,
  AppOutgoingEventPayloadCommandDataSection Data) : ICommand<Result<AppOutgoingEventPayloadSingleDTO>>;

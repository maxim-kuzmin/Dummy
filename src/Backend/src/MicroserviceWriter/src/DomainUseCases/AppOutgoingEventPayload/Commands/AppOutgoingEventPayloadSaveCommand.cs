namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Commands;

/// <summary>
/// Команда сохранения фиктивного предмета.
/// </summary>
/// <param name="IsUpdate">Обновление?</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Data">Данные.</param>
public record AppOutgoingEventPayloadSaveCommand(
  bool IsUpdate,
  long Id,
  AppOutgoingEventPayloadCommandDataSection Data) : ICommand<Result<AppOutgoingEventPayloadSingleDTO>>;

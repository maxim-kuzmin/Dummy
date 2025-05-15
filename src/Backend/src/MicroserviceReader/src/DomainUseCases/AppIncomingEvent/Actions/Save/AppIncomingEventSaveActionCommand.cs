namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Actions.Save;

/// <summary>
/// Команда действия по сохранению входящего события приложения.
/// </summary>
/// <param name="HasEntityBeingSavedAlreadyBeenCreated">Была ли уже создана сохраняемая сущность?</param>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="EventId">Идентификатор события.</param>
/// <param name="EventName">Имя события.</param>
/// <param name="LastLoadingAt">Последняя дата загрузки.</param>
/// <param name="LastLoadingError">Последняя ошибка загрузки.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="PayloadCount">Количество полезной нагрузки.</param>
/// <param name="PayloadTotalCount">Общее количество полезной нагрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventSaveActionCommand(
  bool HasEntityBeingSavedAlreadyBeenCreated,
  string ObjectId,
  string EventId,
  string EventName,
  DateTimeOffset? LastLoadingAt,
  string? LastLoadingError,
  DateTimeOffset? LoadedAt,
  int PayloadCount,
  int PayloadTotalCount,
  DateTimeOffset? ProcessedAt) :
  AppIncomingEventInsertSingleCommand(
    EventId,
    EventName,
    LastLoadingAt,
    LastLoadingError,
    LoadedAt,
    PayloadCount,
    PayloadTotalCount,
    ProcessedAt),
  ICommand<Result<AppIncomingEventSingleDTO>>;

namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Save;

/// <summary>
/// Команда действия по сохранению входящего события приложения.
/// </summary>
/// <param name="HasEntityBeingSavedAlreadyBeenCreated">Была ли уже создана сохраняемая сущность?</param>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Name">Имя.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventSaveActionCommand(
  bool HasEntityBeingSavedAlreadyBeenCreated,
  string ObjectId,
  string Name,
  DateTimeOffset? LoadedAt,
  DateTimeOffset? ProcessedAt) : ICommand<Result<AppIncomingEventSingleDTO>>;

namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Actions.Save;

/// <summary>
/// Команда действия по сохранению исходящего события приложения.
/// </summary>
/// <param name="HasEntityBeingSavedAlreadyBeenCreated">Была ли уже создана сохраняемая сущность?</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventSaveActionCommand(
  bool HasEntityBeingSavedAlreadyBeenCreated,
  long Id,
  string Name,
  DateTimeOffset? PublishedAt) : ICommand<Result<AppOutgoingEventSingleDTO>>;

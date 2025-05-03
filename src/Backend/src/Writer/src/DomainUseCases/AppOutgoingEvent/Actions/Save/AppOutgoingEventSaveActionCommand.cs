namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Save;

/// <summary>
/// Команда действия по сохранению исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventSaveActionCommand(
  long Id,
  string Name,
  DateTimeOffset? PublishedAt) : ICommand<Result<AppOutgoingEventSingleDTO>>;

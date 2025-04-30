namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Update;

/// <summary>
/// Команда действия по обновлению исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventUpdateActionCommand(
  long Id,
  string Name,
  DateTimeOffset? PublishedAt) : ICommand<Result<AppOutgoingEventSingleDTO>>;

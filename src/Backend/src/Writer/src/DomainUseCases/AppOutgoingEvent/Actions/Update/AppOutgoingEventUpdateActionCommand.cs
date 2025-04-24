namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Update;

/// <summary>
/// Команда действия по обновлению исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppOutgoingEventUpdateActionCommand(
  long Id,
  bool IsPublished,
  string Name) : ICommand<Result<AppOutgoingEventSingleDTO>>;

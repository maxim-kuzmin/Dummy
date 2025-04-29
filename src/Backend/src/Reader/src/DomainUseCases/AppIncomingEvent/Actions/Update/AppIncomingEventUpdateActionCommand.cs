namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Update;

/// <summary>
/// Команда действия по обновлению входящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppIncomingEventUpdateActionCommand(
  long Id,
  bool IsPublished,
  string Name) : ICommand<Result<AppIncomingEventSingleDTO>>;

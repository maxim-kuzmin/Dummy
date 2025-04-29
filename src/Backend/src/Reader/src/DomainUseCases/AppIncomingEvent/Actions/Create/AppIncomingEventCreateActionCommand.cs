namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Create;

/// <summary>
/// Команда действия по созданию входящего события приложения.
/// </summary>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppIncomingEventCreateActionCommand(
  bool IsPublished,
  string Name) : ICommand<Result<AppIncomingEventSingleDTO>>;

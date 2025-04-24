namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Create;

/// <summary>
/// Команда действия по созданию исходящего события приложения.
/// </summary>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppOutgoingEventCreateActionCommand(
  bool IsPublished,
  string Name) : ICommand<Result<AppOutgoingEventSingleDTO>>;

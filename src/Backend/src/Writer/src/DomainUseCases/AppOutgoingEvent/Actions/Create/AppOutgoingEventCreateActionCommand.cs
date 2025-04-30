namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Create;

/// <summary>
/// Команда действия по созданию исходящего события приложения.
/// </summary>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventCreateActionCommand(  
  string Name,
  DateTimeOffset? PublishedAt) : ICommand<Result<AppOutgoingEventSingleDTO>>;

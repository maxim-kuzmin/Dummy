namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Save;

/// <summary>
/// Команда действия по сохранению исходящего события приложения.
/// </summary>
/// <param name="ShouldEntityBeFoundById">Должна ли сущность быть найдена по идентификатору</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventSaveActionCommand(
  bool ShouldEntityBeFoundById,
  long Id,
  string Name,
  DateTimeOffset? PublishedAt) : ICommand<Result<AppOutgoingEventSingleDTO>>;

namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Update;

/// <summary>
/// Команда действия по обновлению входящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventUpdateActionCommand(
  long Id,
  string Name,
  DateTimeOffset? LoadedAt,
  DateTimeOffset? ProcessedAt) : ICommand<Result<AppIncomingEventSingleDTO>>;

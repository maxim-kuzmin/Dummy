namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Create;

/// <summary>
/// Команда действия по созданию входящего события приложения.
/// </summary>
/// <param name="Name">Имя.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventCreateActionCommand(  
  string Name,
  DateTimeOffset? LoadedAt,
  DateTimeOffset? ProcessedAt) : ICommand<Result<AppIncomingEventSingleDTO>>;

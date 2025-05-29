namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutbox.Commands;

/// <summary>
/// Команда выдачи исходящего сообщения приложения.
/// </summary>
/// <param name="EventMaxCountToPublish">Максимальное количество сообщений для публикации.</param>
public record AppOutboxProduceCommand(int EventMaxCountToPublish) : ICommand<Result>;

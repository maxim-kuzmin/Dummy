using Makc.Dummy.Reader.DomainUseCases.AppInbox.Actions.Load;

namespace Makc.Dummy.Reader.DomainUseCases.AppInbox.Services;

/// <summary>
/// Сервис входящих сообщений приложения.
/// </summary>
/// <param name="_appIncomingEventCommandService">Сервис команд входящего события приложения.</param>
public class AppInboxCommandService(
  IAppIncomingEventCommandService _appIncomingEventCommandService) : IAppInboxCommandService
{
  /// <summary>
  /// Потребить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  public Task<Result> Consume(AppInboxConsumeActionCommand command, CancellationToken cancellationToken)
  {
    string[] eventIds = command.Message.Contains(',')
      ? command.Message.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
      : [];

    return eventIds.Length > 0
      ? InsertAppIncomingEvents(eventIds, command.Sender, cancellationToken)
      : Task.FromResult(Result.NoContent());
  }

  /// <inheritdoc/>
  public Task<Result> Load(AppInboxLoadActionCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  private Task<Result> InsertAppIncomingEvents(
    string[] eventIds,
    string eventName,
    CancellationToken cancellationToken)
  {
    AppIncomingEventInsertListCommand command = new([..eventIds.Select(eventId =>
      new AppIncomingEventInsertSingleCommand(
        EventId: eventId,
        EventName: eventName,
        LastLoadingAt: null,
        LastLoadingError: null,
        LoadedAt: null,
        PayloadCount: 0,
        PayloadTotalCount: 0,
        ProcessedAt: null))]);

    return _appIncomingEventCommandService.InsertList(command, cancellationToken);
  }
}

using Makc.Dummy.Shared.Core.App;

namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Services;

/// <summary>
/// Сервис исходящего сообщения приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_appOutgoingEventCommandService">Сервис команд исходящего события приложения.</param>
/// <param name="_appOutgoingEventPayloadCommandService">
/// Сервис команд полезной нагрузки исходящего события приложения.
/// </param>
public class AppOutboxCommandService(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutgoingEventCommandService _appOutgoingEventCommandService,
  IAppOutgoingEventPayloadCommandService _appOutgoingEventPayloadCommandService) : IAppOutboxCommandService
{
  /// <inheritdoc/>>
  public async Task<AppCommandResultWithoutValue> Save(
    AppOutboxSaveActionCommand command,
    CancellationToken cancellationToken)
  {
    List<AppEventPayloadWithDataAsDictionary> payloads = [];

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      var resultForAppOutgoingEvent = await CreateAppOutgoingEvent(command, cancellationToken).ConfigureAwait(false);

      resultForAppOutgoingEvent.Data.ThrowExceptionIfNotSuccess();

      payloads.AddRange(resultForAppOutgoingEvent.Payloads);

      long appOutgoingEventId = resultForAppOutgoingEvent.Data.Value.Id;

      foreach (var payload in command.Payloads)
      {
        var task = CreateAppOutgoingEventPayload(appOutgoingEventId, payload, cancellationToken);

        var resultForAppOutgoingEventPayload = await task.ConfigureAwait(false);

        resultForAppOutgoingEventPayload.Data.ThrowExceptionIfNotSuccess();

        payloads.AddRange(resultForAppOutgoingEventPayload.Payloads);
      }
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    AppCommandResultWithoutValue result = new(Result.NoContent());

    result.Payloads.AddRange(payloads);

    return result;
  }

  private Task<AppCommandResultWithValue<AppOutgoingEventSingleDTO>> CreateAppOutgoingEvent(
    AppOutboxSaveActionCommand request,
    CancellationToken cancellationToken)
  {
    var command = request.ToAppOutgoingEventSaveActionCommand();

    return _appOutgoingEventCommandService.Save(command, cancellationToken);
  }

  private Task<AppCommandResultWithValue<AppOutgoingEventPayloadSingleDTO>> CreateAppOutgoingEventPayload(
    long appOutgoingEventId,
    AppEventPayloadWithDataAsString payload,
    CancellationToken cancellationToken)
  {
    var command = payload.ToAppOutgoingEventPayloadSaveActionCommand(appOutgoingEventId);

    return _appOutgoingEventPayloadCommandService.Save(command, cancellationToken);
  }
}

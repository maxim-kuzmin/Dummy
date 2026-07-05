namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppInbox.Actions.Clear;

/// <summary>
/// Обработчик действия по очистке входящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppInboxClearActionHandler(IAppInboxCommandService _service) :
  IRequestHandler<AppInboxClearActionRequest, Result>
{
  /// <inheritdoc/>
  public async ValueTask<Result> Handle(AppInboxClearActionRequest request, CancellationToken cancellationToken)
  {
    await _service.Clear(request.Command, cancellationToken).ConfigureAwait(false);

    return Result.NoContent();
  }
}

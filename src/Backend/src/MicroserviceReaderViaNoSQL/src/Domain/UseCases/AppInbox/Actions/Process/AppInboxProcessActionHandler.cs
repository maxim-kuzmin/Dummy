namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppInbox.Actions.Process;

/// <summary>
/// Обработчик действия по обработке входящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppInboxProcessActionHandler(IAppInboxCommandService _service) :
  IRequestHandler<AppInboxProcessActionRequest, Result>
{
  /// <inheritdoc/>
  public async ValueTask<Result> Handle(AppInboxProcessActionRequest request, CancellationToken cancellationToken)
  {
    var result = await _service.Process(request.Command, cancellationToken).ConfigureAwait(false);

    return result.IsSuccess ? Result.NoContent() : result;
  }
}

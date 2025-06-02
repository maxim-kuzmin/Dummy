namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Actions.Process;

/// <summary>
/// Обработчик действия по обработке входящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppInboxProcessActionHandler(IAppInboxCommandService _service) :
  ICommandHandler<AppInboxProcessActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppInboxProcessActionRequest request, CancellationToken cancellationToken)
  {
    var result = await _service.Process(request.Command, cancellationToken).ConfigureAwait(false);

    return result.IsSuccess ? Result.NoContent() : result;
  }
}

namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppInbox.Actions.Consume;

/// <summary>
/// Обработчик действия по потреблению входящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppInboxConsumeActionHandler(IAppInboxCommandService _service) :
  ICommandHandler<AppInboxConsumeActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppInboxConsumeActionRequest request, CancellationToken cancellationToken)
  {
    var result = await _service.Consume(request.Command, cancellationToken).ConfigureAwait(false);

    return result.IsSuccess ? Result.NoContent() : result;
  }
}

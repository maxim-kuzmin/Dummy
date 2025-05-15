namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppInbox.Actions.Consume;

/// <summary>
/// Обработчик действия по потреблению входящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppInboxConsumeActionHandler(IAppInboxCommandService _service) :
  ICommandHandler<AppInboxConsumeActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppInboxConsumeActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _service.Consume(request, cancellationToken);

    return result.IsSuccess ? Result.NoContent() : result;
  }
}

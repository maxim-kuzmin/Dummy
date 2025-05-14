namespace Makc.Dummy.Reader.DomainUseCases.AppInbox.Actions.Consume;

/// <summary>
/// Обработчик действия по потреблению входящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppInboxConsumeActionHandler(IAppInboxCommandService _service) :
  ICommandHandler<AppInboxConsumeActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppInboxConsumeActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Consume(request, cancellationToken);
  }
}

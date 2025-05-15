namespace Makc.Dummy.Reader.DomainUseCases.AppInbox.Actions.Load;

/// <summary>
/// Обработчик действия по загрузке входящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppInboxLoadActionHandler(IAppInboxCommandService _service) :
  ICommandHandler<AppInboxLoadActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppInboxLoadActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Load(request, cancellationToken);
  }
}

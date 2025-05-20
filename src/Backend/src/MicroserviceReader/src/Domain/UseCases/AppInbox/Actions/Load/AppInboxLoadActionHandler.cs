namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Actions.Load;

/// <summary>
/// Обработчик действия по загрузке входящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppInboxLoadActionHandler(IAppInboxCommandService _service) :
  ICommandHandler<AppInboxLoadActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppInboxLoadActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _service.Load(request, cancellationToken);

    return result.IsSuccess ? Result.NoContent() : result;
  }
}

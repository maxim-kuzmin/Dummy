namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Actions.Load;

/// <summary>
/// Обработчик действия по загрузке входящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppInboxLoadActionHandler(IAppInboxCommandService _service) :
  ICommandHandler<AppInboxLoadActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppInboxLoadActionRequest request, CancellationToken cancellationToken)
  {
    var result = await _service.Load(request.Command, cancellationToken);

    return result.IsSuccess ? Result.NoContent() : result;
  }
}

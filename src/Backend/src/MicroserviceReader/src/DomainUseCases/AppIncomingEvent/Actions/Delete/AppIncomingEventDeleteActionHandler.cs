namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventDeleteActionHandler(IAppIncomingEventCommandService _service) :
  ICommandHandler<AppIncomingEventDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppIncomingEventDeleteActionRequest request, CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

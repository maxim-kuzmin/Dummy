namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventDeleteActionHandler(IAppIncomingEventCommandService _service) :
  ICommandHandler<AppIncomingEventDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppIncomingEventDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

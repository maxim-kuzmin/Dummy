namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventSaveActionHandler(IAppIncomingEventCommandService _service) :
  ICommandHandler<AppIncomingEventSaveActionCommand, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventSaveActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Save(request, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

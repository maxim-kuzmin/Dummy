namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventSaveActionHandler(IAppOutgoingEventCommandService _service) :
  ICommandHandler<AppOutgoingEventSaveActionCommand, Result<AppOutgoingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventSingleDTO>> Handle(
    AppOutgoingEventSaveActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Save(request, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

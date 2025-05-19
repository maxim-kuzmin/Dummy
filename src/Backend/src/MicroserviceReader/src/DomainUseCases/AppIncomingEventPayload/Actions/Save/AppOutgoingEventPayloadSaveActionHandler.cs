namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadSaveActionHandler(IAppIncomingEventPayloadCommandService _service) :
  ICommandHandler<AppIncomingEventPayloadSaveActionCommand, Result<AppIncomingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadSingleDTO>> Handle(
    AppIncomingEventPayloadSaveActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Save(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

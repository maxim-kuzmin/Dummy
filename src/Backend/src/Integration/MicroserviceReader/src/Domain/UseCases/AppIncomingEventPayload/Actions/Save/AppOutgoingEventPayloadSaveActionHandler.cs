namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadSaveActionHandler(IAppIncomingEventPayloadCommandService _service) :
  ICommandHandler<AppIncomingEventPayloadSaveActionCommand, Result<AppIncomingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppIncomingEventPayloadSingleDTO>> Handle(
    AppIncomingEventPayloadSaveActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Save(request.Command, cancellationToken);
  }
}

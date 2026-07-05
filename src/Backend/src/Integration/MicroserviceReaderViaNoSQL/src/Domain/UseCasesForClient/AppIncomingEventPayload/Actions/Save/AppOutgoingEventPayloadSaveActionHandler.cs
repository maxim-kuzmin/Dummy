namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEventPayload.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadSaveActionHandler(IAppIncomingEventPayloadCommandService _service) :
  IRequestHandler<AppIncomingEventPayloadSaveActionCommand, Result<AppIncomingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppIncomingEventPayloadSingleDTO>> Handle(
    AppIncomingEventPayloadSaveActionCommand request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppIncomingEventPayloadSingleDTO>>(_service.Save(request.Command, cancellationToken));
  }
}

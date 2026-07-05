namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEventPayload.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadSaveActionHandler(IAppOutgoingEventPayloadCommandService _service) :
  IRequestHandler<AppOutgoingEventPayloadSaveActionRequest, Result<AppOutgoingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppOutgoingEventPayloadSingleDTO>> Handle(
    AppOutgoingEventPayloadSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppOutgoingEventPayloadSingleDTO>>(_service.Save(request.Command, cancellationToken));
  }
}

namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEventPayload.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadSaveActionHandler(IAppOutgoingEventPayloadCommandService _service) :
  ICommandHandler<AppOutgoingEventPayloadSaveActionRequest, Result<AppOutgoingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppOutgoingEventPayloadSingleDTO>> Handle(
    AppOutgoingEventPayloadSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.Save(request.Command, cancellationToken);
  }
}

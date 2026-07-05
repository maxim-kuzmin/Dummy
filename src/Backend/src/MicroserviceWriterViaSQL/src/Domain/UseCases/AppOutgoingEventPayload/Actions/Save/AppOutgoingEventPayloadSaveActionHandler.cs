namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadSaveActionHandler(IAppOutgoingEventPayloadCommandService _service) :
  IRequestHandler<AppOutgoingEventPayloadSaveActionRequest, Result<AppOutgoingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async ValueTask<Result<AppOutgoingEventPayloadSingleDTO>> Handle(
    AppOutgoingEventPayloadSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Save(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

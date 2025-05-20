namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadSaveActionHandler(IAppOutgoingEventPayloadCommandService _service) :
  ICommandHandler<AppOutgoingEventPayloadSaveActionRequest, Result<AppOutgoingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadSingleDTO>> Handle(
    AppOutgoingEventPayloadSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Save(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadDeleteActionHandler(IAppOutgoingEventPayloadCommandService _service) :
  ICommandHandler<AppOutgoingEventPayloadDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(
    AppOutgoingEventPayloadDeleteActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

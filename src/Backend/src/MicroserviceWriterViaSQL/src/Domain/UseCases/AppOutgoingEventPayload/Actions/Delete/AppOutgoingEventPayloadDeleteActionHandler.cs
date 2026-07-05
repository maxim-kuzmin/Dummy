namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadDeleteActionHandler(IAppOutgoingEventPayloadCommandService _service) :
  IRequestHandler<AppOutgoingEventPayloadDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public async ValueTask<Result> Handle(
    AppOutgoingEventPayloadDeleteActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadDeleteActionHandler(IAppOutgoingEventPayloadCommandService _service) :
  IRequestHandler<AppOutgoingEventPayloadDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public ValueTask<Result> Handle(AppOutgoingEventPayloadDeleteActionRequest request, CancellationToken cancellationToken)
  {
    return new ValueTask<Result>(_service.Delete(request.Command, cancellationToken));
  }
}

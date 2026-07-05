namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadDeleteActionHandler(IAppIncomingEventPayloadCommandService _service) :
  IRequestHandler<AppIncomingEventPayloadDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public ValueTask<Result> Handle(
    AppIncomingEventPayloadDeleteActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result>(_service.Delete(request.Command, cancellationToken));
  }
}

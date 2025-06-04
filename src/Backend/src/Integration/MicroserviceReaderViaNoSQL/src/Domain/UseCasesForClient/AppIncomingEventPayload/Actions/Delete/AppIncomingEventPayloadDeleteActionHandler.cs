namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadDeleteActionHandler(IAppIncomingEventPayloadCommandService _service) :
  ICommandHandler<AppIncomingEventPayloadDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(
    AppIncomingEventPayloadDeleteActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.Delete(request.Command, cancellationToken);
  }
}

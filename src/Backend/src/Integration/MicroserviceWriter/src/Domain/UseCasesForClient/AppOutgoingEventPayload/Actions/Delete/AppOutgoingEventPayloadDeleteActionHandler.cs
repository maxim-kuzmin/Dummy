namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCasesForClient.AppOutgoingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadDeleteActionHandler(IAppOutgoingEventPayloadCommandService _service) :
  ICommandHandler<AppOutgoingEventPayloadDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppOutgoingEventPayloadDeleteActionRequest request, CancellationToken cancellationToken)
  {
    return _service.Delete(request.Command, cancellationToken);
  }
}

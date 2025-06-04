namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEvent.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventSaveActionHandler(IAppOutgoingEventCommandService _service) :
  ICommandHandler<AppOutgoingEventSaveActionRequest, Result<AppOutgoingEventSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppOutgoingEventSingleDTO>> Handle(
    AppOutgoingEventSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.Save(request.Command, cancellationToken);
  }
}

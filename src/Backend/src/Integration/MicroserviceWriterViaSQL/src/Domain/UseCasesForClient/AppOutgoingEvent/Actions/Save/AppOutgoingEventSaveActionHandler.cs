namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEvent.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventSaveActionHandler(IAppOutgoingEventCommandService _service) :
  IRequestHandler<AppOutgoingEventSaveActionRequest, Result<AppOutgoingEventSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppOutgoingEventSingleDTO>> Handle(
    AppOutgoingEventSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppOutgoingEventSingleDTO>>(_service.Save(request.Command, cancellationToken));
  }
}

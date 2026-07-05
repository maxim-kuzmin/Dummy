namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEvent.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventSaveActionHandler(IAppIncomingEventCommandService _service) :
  IRequestHandler<AppIncomingEventSaveActionRequest, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppIncomingEventSingleDTO>>(_service.Save(request.Command, cancellationToken));
  }
}

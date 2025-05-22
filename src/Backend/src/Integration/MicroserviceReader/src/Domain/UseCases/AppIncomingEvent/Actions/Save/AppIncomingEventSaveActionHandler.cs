namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventSaveActionHandler(IAppIncomingEventCommandService _service) :
  ICommandHandler<AppIncomingEventSaveActionRequest, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.Save(request.Command, cancellationToken);
  }
}

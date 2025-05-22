namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventSaveActionHandler(IAppIncomingEventCommandService _service) :
  ICommandHandler<AppIncomingEventSaveActionRequest, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventSaveActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Save(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

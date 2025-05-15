namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadDeleteActionHandler(IAppIncomingEventPayloadCommandService _service) :
  ICommandHandler<AppIncomingEventPayloadDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(
    AppIncomingEventPayloadDeleteActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

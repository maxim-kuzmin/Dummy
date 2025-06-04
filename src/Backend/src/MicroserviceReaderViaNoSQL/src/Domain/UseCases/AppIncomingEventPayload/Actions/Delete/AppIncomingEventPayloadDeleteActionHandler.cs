namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadDeleteActionHandler(IAppIncomingEventPayloadCommandService _service) :
  ICommandHandler<AppIncomingEventPayloadDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(
    AppIncomingEventPayloadDeleteActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

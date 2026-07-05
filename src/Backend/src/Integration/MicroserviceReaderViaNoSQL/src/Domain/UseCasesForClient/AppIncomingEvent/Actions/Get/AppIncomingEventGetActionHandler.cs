namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetActionHandler(IAppIncomingEventQueryService _service) :
  IRequestHandler<AppIncomingEventGetActionRequest, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventGetActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppIncomingEventSingleDTO>>(_service.GetSingle(request.Query, cancellationToken));
  }
}

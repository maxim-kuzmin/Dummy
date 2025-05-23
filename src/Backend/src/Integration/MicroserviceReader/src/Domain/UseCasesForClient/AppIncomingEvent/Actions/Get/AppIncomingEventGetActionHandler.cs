namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCasesForClient.AppIncomingEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetActionHandler(IAppIncomingEventQueryService _service) :
  IQueryHandler<AppIncomingEventGetActionRequest, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventGetActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetSingle(request.Query, cancellationToken);
  }
}

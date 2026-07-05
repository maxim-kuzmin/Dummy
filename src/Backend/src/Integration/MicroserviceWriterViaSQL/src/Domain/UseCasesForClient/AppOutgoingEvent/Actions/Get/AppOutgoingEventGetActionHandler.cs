namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetActionHandler(IAppOutgoingEventQueryService _service) :
  IRequestHandler<AppOutgoingEventGetActionRequest, Result<AppOutgoingEventSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppOutgoingEventSingleDTO>> Handle(
    AppOutgoingEventGetActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppOutgoingEventSingleDTO>>(_service.GetSingle(request.Query, cancellationToken));
  }
}

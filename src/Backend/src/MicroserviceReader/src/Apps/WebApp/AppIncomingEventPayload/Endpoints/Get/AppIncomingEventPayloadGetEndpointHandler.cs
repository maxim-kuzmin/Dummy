namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEventPayload.Endpoints.Get;

/// <summary>
/// Обработчик конечной точки получения полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventPayloadGetEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventPayloadGetActionQuery, AppIncomingEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppIncomingEventPayloadGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventPayloadGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

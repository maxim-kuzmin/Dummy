namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEventPayload.Endpoints.Get;

/// <summary>
/// Обработчик конечной точки получения полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventPayloadGetEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventPayloadGetEndpointRequest, AppOutgoingEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppOutgoingEventPayloadGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppOutgoingEventPayloadGetEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventPayloadGetActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult()).ConfigureAwait(false);
  }
}

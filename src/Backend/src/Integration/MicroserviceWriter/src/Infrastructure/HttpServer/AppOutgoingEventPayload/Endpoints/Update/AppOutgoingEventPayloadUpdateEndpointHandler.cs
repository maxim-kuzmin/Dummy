namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEventPayload.Endpoints.Update;

/// <summary>
/// Обработчик конечной точки обновления полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventPayloadUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventPayloadUpdateEndpointRequest, AppOutgoingEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(AppOutgoingEventPayloadUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppOutgoingEventPayloadUpdateEndpointRequest
    request, CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventPayloadSaveActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

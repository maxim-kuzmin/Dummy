namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEventPayload.Endpoints.Update;

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
    var command = request.ToAppOutgoingEventPayloadSaveActionCommand();

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

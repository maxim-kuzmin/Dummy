namespace Makc.Dummy.Reader.Apps.WebApp.AppIncomingEventPayload.Endpoints.Update;

/// <summary>
/// Обработчик конечной точки обновления полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventPayloadUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventPayloadUpdateEndpointRequest, AppIncomingEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(AppIncomingEventPayloadUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventPayloadUpdateEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var command = request.ToAppIncomingEventPayloadSaveActionCommand();

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

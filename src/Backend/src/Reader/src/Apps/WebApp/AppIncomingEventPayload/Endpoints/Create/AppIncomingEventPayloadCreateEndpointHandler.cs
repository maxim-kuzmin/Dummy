namespace Makc.Dummy.Reader.Apps.WebApp.AppIncomingEventPayload.Endpoints.Create;

/// <summary>
/// Обработчик конечной точки создания полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventPayloadCreateEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventPayloadCreateEndpointRequest, long>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppIncomingEventPayloadCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventPayloadCreateEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var command = request.ToAppIncomingEventPayloadSaveActionCommand();

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEvent.Endpoints.Create;

/// <summary>
/// Обработчик конечной точки создания исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventCreateEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventCreateEndpointRequest, long>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppOutgoingEventCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppOutgoingEventCreateEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var command = request.ToAppOutgoingEventSaveActionRequest();

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

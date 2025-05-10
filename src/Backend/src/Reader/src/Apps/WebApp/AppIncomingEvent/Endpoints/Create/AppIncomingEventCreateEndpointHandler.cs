namespace Makc.Dummy.Reader.Apps.WebApp.AppIncomingEvent.Endpoints.Create;

/// <summary>
/// Обработчик конечной точки создания входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventCreateEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventCreateEndpointRequest, long>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppIncomingEventCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventCreateEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var command = request.ToAppIncomingEventSaveActionCommand();

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

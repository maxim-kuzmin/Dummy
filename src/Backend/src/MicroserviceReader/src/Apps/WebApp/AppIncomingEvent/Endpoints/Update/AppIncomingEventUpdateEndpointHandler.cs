namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEvent.Endpoints.Update;

/// <summary>
/// Обработчик конечной точки обновления входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventUpdateEndpointRequest, AppIncomingEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(AppIncomingEventUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventUpdateEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var command = request.ToAppIncomingEventSaveActionCommand();

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

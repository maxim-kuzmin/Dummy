namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEvent.Endpoints.Get;

/// <summary>
/// Обработчик конечной точки получения входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventGetEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventGetActionQuery, AppIncomingEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppIncomingEventGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

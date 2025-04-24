namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEvent.Endpoints.Get;

/// <summary>
/// Обработчик конечной точки получения исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventGetEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventGetActionQuery, AppOutgoingEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppOutgoingEventGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppOutgoingEventGetActionQuery request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

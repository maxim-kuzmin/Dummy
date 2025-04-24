namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEvent.Endpoints.Create;

/// <summary>
/// Обработчик конечной точки создания исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventCreateEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventCreateActionCommand, long>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppOutgoingEventCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppOutgoingEventCreateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

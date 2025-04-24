namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEventPayload.Endpoints.Create;

/// <summary>
/// Обработчик конечной точки создания полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventPayloadCreateEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventPayloadCreateActionCommand, long>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppOutgoingEventPayloadCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppOutgoingEventPayloadCreateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

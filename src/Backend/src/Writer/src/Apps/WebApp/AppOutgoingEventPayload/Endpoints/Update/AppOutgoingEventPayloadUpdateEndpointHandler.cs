namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEventPayload.Endpoints.Update;

/// <summary>
/// Обработчик конечной точки обновления полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventPayloadUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventPayloadUpdateActionCommand, AppOutgoingEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(AppOutgoingEventPayloadUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppOutgoingEventPayloadUpdateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

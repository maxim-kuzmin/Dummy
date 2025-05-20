namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Web.AppOutgoingEventPayload.Endpoints.Create;

/// <summary>
/// Обработчик конечной точки создания полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventPayloadCreateEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventPayloadCreateEndpointRequest, long>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppOutgoingEventPayloadCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppOutgoingEventPayloadCreateEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventPayloadSaveActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

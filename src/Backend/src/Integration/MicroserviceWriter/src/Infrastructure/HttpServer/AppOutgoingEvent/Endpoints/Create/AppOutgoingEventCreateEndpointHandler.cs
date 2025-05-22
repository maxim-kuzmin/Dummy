namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.Create;

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
    var task = _mediator.Send(request.ToAppOutgoingEventSaveActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

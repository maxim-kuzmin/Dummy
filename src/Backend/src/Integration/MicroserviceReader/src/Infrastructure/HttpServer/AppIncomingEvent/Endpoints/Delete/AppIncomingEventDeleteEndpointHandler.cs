namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventDeleteEndpointRequest, AppIncomingEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(AppIncomingEventDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventDeleteEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppIncomingEventDeleteActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

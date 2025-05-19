namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEvent.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventDeleteEndpointRequest, AppOutgoingEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(AppOutgoingEventDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppOutgoingEventDeleteEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventDeleteActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

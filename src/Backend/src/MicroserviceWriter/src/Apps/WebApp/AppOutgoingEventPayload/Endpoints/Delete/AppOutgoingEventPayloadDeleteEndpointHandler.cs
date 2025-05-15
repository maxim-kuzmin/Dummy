namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEventPayload.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventPayloadDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventPayloadDeleteActionCommand, AppOutgoingEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(AppOutgoingEventPayloadDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppOutgoingEventPayloadDeleteActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

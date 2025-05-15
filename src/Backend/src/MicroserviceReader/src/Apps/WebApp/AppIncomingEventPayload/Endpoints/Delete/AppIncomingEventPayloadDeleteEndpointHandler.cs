namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEventPayload.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventPayloadDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventPayloadDeleteActionCommand, AppIncomingEventPayloadSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(AppIncomingEventPayloadDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventPayloadDeleteActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

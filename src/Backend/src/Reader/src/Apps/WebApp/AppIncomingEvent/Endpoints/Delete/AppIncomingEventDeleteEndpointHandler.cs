namespace Makc.Dummy.Reader.Apps.WebApp.AppIncomingEvent.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventDeleteActionCommand, AppIncomingEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(AppIncomingEventDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventDeleteActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

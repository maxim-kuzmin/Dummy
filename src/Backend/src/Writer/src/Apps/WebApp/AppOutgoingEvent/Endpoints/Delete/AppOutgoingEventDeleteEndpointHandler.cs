namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEvent.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventDeleteActionCommand, AppOutgoingEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(AppOutgoingEventDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppOutgoingEventDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

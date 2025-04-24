namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEvent.Endpoints.Update;

/// <summary>
/// Обработчик конечной точки обновления исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventUpdateActionCommand, AppOutgoingEventSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(AppOutgoingEventUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppOutgoingEventUpdateActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

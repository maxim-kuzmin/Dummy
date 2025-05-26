namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.GetPage;

/// <summary>
/// Обработчик конечной точки получения списка исходящих событий приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventGetPageEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventGetPageEndpointRequest, AppOutgoingEventPageDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppOutgoingEventGetPageEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppOutgoingEventGetPageEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventGetPageActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

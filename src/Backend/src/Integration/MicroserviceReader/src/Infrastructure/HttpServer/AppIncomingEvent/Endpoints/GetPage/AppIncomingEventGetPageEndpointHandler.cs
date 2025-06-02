namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.GetPage;

/// <summary>
/// Обработчик конечной точки получения списка входящих событий приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventGetPageEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventGetPageEndpointRequest, AppIncomingEventPageDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppIncomingEventGetPageEndpointSettings.Route);
    AllowAnonymous();// //makc//!!!//AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventGetPageEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppIncomingEventGetPageActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult()).ConfigureAwait(false);
  }
}

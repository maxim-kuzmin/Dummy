namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.GetPage;

/// <summary>
/// Обработчик конечной точки получения списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventPayloadGetPageEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventPayloadGetPageEndpointRequest, AppIncomingEventPayloadPageDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppIncomingEventPayloadGetPageEndpointSettings.Route);
    AllowAnonymous();// //makc//!!!//AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventPayloadGetPageEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppIncomingEventPayloadGetPageActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult()).ConfigureAwait(false);
  }
}

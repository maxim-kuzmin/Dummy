namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.AppOutgoingEventPayload.Endpoints.GetPage;

/// <summary>
/// Обработчик конечной точки получения страницы полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventPayloadGetPageEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventPayloadGetPageEndpointRequest, AppOutgoingEventPayloadPageDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppOutgoingEventPayloadGetPageEndpointSettings.Route);
    AllowAnonymous();// //makc//!!!//AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppOutgoingEventPayloadGetPageEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventPayloadGetPageActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult()).ConfigureAwait(false);
  }
}

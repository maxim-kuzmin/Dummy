namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEventPayload.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventPayloadGetListEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventPayloadGetListEndpointRequest, IEnumerable<AppIncomingEventPayloadListDTO>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppIncomingEventPayloadGetListEndpointSettings.Route);
    AllowAnonymous();// //makc//!!!//AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventPayloadGetListEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAppIncomingEventPayloadGetListActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

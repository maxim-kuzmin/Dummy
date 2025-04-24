namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEventPayload.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventPayloadGetListEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventPayloadGetListEndpointRequest, IEnumerable<AppOutgoingEventPayloadListDTO>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppOutgoingEventPayloadGetListEndpointSettings.Route);
    AllowAnonymous();// //makc//!!!//AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppOutgoingEventPayloadGetListEndpointRequest request, CancellationToken cancellationToken)
  {
    AppOutgoingEventPayloadGetListActionQuery query = request.ToAppOutgoingEventPayloadGetListActionQuery();

    var result = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

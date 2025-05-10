namespace Makc.Dummy.Reader.Apps.WebApp.AppIncomingEvent.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка входящих событий приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppIncomingEventGetListEndpointHandler(IMediator _mediator) :
  Endpoint<AppIncomingEventGetListEndpointRequest, IEnumerable<AppIncomingEventListDTO>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppIncomingEventGetListEndpointSettings.Route);
    AllowAnonymous();// //makc//!!!//AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppIncomingEventGetListEndpointRequest request,
    CancellationToken cancellationToken)
  {
    AppIncomingEventGetListActionQuery query = request.ToAppIncomingEventGetListActionQuery();

    var result = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

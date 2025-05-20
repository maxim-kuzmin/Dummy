namespace Makc.Dummy.MicroserviceReader.Infrastructure.Web.AppIncomingEvent.Endpoints.GetList;

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
    var task = _mediator.Send(request.ToAppIncomingEventGetListActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

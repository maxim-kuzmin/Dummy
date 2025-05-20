namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Web.AppOutgoingEvent.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка исходящих событий приложения.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppOutgoingEventGetListEndpointHandler(IMediator _mediator) :
  Endpoint<AppOutgoingEventGetListEndpointRequest, IEnumerable<AppOutgoingEventListDTO>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(AppOutgoingEventGetListEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    AppOutgoingEventGetListEndpointRequest request,
    CancellationToken cancellationToken)
  {
    AppOutgoingEventGetListActionRequest query = request.ToAppOutgoingEventGetListActionRequest();

    var result = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

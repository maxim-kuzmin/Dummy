namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.DummyItem.Endpoints.Get;

/// <summary>
/// Обработчик конечной точки получения фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetEndpointRequest, DummyItemSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(DummyItemGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemGetEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToDummyItemGetActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

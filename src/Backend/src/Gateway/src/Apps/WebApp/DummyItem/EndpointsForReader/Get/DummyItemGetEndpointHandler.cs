namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForReader.Get;

/// <summary>
/// Обработчик конечной точки получения фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetActionQueryForReader, DummyItemSingleDTOForReader>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(DummyItemGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemGetActionQueryForReader request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForWriter.Get;

/// <summary>
/// Обработчик конечной точки получения фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetActionQueryForWriter, DummyItemSingleDTOForWriter>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(DummyItemGetEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemGetActionQueryForWriter request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

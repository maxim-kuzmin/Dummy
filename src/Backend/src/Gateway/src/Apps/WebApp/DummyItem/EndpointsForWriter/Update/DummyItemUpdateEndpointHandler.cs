namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForMicroserviceWriter.Update;

/// <summary>
/// Обработчик конечной точки обновления фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemUpdateActionCommandForMicroserviceWriter, DummyItemSingleDTOForMicroserviceWriter>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(DummyItemUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemUpdateActionCommandForMicroserviceWriter request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

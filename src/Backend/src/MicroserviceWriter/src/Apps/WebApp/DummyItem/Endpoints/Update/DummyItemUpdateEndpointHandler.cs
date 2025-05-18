namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.DummyItem.Endpoints.Update;

/// <summary>
/// Обработчик конечной точки обновления фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemUpdateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemUpdateEndpointRequest, DummyItemSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Put(DummyItemUpdateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemUpdateEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var command = request.ToDummyItemSaveActionRequest();

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForMicroserviceWriter.Delete;

/// <summary>
/// Обработчик конечной точки удаления фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemDeleteActionCommandForMicroserviceWriter>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(DummyItemDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemDeleteActionCommandForMicroserviceWriter request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForWriter.Create;

/// <summary>
/// Обработчик конечной точки создания фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemCreateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemCreateActionCommandForWriter, Result<DummyItemSingleDTOForWriter>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(DummyItemCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemCreateActionCommandForWriter request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

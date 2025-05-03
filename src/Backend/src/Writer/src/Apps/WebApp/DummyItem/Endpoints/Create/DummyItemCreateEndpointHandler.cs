namespace Makc.Dummy.Writer.Apps.WebApp.DummyItem.Endpoints.Create;

/// <summary>
/// Обработчик конечной точки создания фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemCreateEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemCreateEndpointRequest, long>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(DummyItemCreateEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(DummyItemCreateEndpointRequest request, CancellationToken cancellationToken)
  {
    var command = request.ToDummyItemSaveActionCommand();

    var result = await _mediator.Send(command, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

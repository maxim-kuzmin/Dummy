namespace Makc.Dummy.Gateway.Infrastructure.WebForMicroserviceWriter.DummyItem.Endpoints.Delete;

/// <summary>
/// Обработчик конечной точки удаления фиктивного предмета.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemDeleteEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemDeleteEndpointRequest, DummyItemSingleDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Delete(DummyItemDeleteEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemDeleteEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToDummyItemDeleteActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

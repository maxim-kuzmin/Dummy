namespace Makc.Dummy.Gateway.Infrastructure.WebForMicroserviceWriter.DummyItem.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка фиктивных предметов.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetListEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetListEndpointRequest, DummyItemListDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(DummyItemGetListEndpointSettings.Route);
    AllowAnonymous();// //makc//!!!//AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemGetListEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToDummyItemGetListActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

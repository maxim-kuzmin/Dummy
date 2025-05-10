namespace Makc.Dummy.Writer.Apps.WebApp.DummyItem.Endpoints.GetList;

/// <summary>
/// Обработчик конечной точки получения списка фиктивных предметов.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetListEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetListEndpointRequest, IEnumerable<DummyItemListDTO>>
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
    var query = request.ToDummyItemGetListActionQuery();

    var result = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

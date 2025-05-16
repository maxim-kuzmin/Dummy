namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForMicroserviceWriter.GetList;

/// <summary>
/// Обработчик конечной точки получения списка фиктивных предметов.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetListEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetListEndpointRequestForMicroserviceWriter, DummyItemListDTOForMicroserviceWriter>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(DummyItemGetListEndpointSettings.Route);
    AllowAnonymous();// //makc//!!!//AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemGetListEndpointRequestForMicroserviceWriter request,
    CancellationToken cancellationToken)
  {
    var query = request.ToDummyItemGetListActionQueryForMicroserviceWriter();

    var result = await _mediator.Send(query, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

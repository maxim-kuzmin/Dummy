namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.DummyItem.Endpoints.GetPage;

/// <summary>
/// Обработчик конечной точки получения страницы фиктивных предметов.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class DummyItemGetPageEndpointHandler(IMediator _mediator) :
  Endpoint<DummyItemGetPageEndpointRequest, IEnumerable<DummyItemPageDTO>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Get(DummyItemGetPageEndpointSettings.Route);
    AllowAnonymous();// //makc//!!!//AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(
    DummyItemGetPageEndpointRequest request,
    CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToDummyItemGetPageActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

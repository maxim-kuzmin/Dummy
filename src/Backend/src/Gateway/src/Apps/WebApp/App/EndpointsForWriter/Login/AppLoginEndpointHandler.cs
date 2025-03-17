namespace Makc.Dummy.Gateway.Apps.WebApp.App.EndpointsForWriter.Login;

/// <summary>
/// Обработчик конечной точки входа в приложение.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AppLoginEndpointHandler(IMediator _mediator) :
  Endpoint<AppLoginActionCommandForWriter, Result<AppLoginDTOForWriter>>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AppLoginEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AppLoginActionCommandForWriter request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

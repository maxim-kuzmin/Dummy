namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.Auth.Endpoints.Login;

/// <summary>
/// Обработчик конечной точки входа для аутентификации.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AuthLoginEndpointHandler(IMediator _mediator) :
  Endpoint<AuthLoginActionCommand, AuthLoginDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AuthLoginEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AuthLoginActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(request, cancellationToken);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}

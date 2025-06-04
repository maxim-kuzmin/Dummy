namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.Auth.Endpoints.Login;

/// <summary>
/// Обработчик конечной точки входа для аутентификации.
/// </summary>
/// <param name="_mediator">Медиатор.</param>
public class AuthLoginEndpointHandler(IMediator _mediator) :
  Endpoint<AuthLoginEndpointRequest, AuthLoginDTO>
{
  /// <inheritdoc/>
  public override void Configure()
  {
    Post(AuthLoginEndpointSettings.Route);
    AllowAnonymous();
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(AuthLoginEndpointRequest request, CancellationToken cancellationToken)
  {
    var task = _mediator.Send(request.ToAuthLoginActionRequest(), cancellationToken);

    var result = await task.ConfigureAwait(false);

    await SendResultAsync(result.ToMinimalApiResult()).ConfigureAwait(false);
  }
}

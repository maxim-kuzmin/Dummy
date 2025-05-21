namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcServer.Auth;

/// <summary>
/// Сервис аутентификации.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AuthService(IMediator _mediator) : AuthServiceBase
{
  /// <summary>
  /// Войти.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <param name="context">Контекст.</param>
  /// <returns>Ответ.</returns>
  public override async Task<AuthLoginGrpcReply> Login(
    AuthLoginGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAuthLoginActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAuthLoginGrpcReply();
  }
}

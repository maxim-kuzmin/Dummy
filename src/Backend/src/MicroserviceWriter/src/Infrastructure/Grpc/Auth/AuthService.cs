namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.Auth;

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
    AuthLoginActionRequest command = request.ToAuthLoginActionRequest();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAuthLoginGrpcReply();
  }
}

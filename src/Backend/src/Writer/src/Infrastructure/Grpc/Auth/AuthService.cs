namespace Makc.Dummy.Writer.Infrastructure.Grpc.Auth;

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
  public override async Task<AuthLoginActionReply> Login(
    AuthLoginActionRequest request,
    ServerCallContext context)
  {
    AuthLoginActionCommand command = request.ToAuthLoginActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAuthLoginActionReply();
  }
}

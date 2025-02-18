namespace Makc.Dummy.Writer.Infrastructure.Grpc.App;

/// <summary>
/// Сервис приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppService(IMediator _mediator) : AppServiceBase
{
  /// <summary>
  /// Войти.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <param name="context">Контекст.</param>
  /// <returns>Ответ.</returns>
  public override async Task<AppLoginActionReply> Login(
    AppLoginActionRequest request,
    ServerCallContext context)
  {
    AppLoginActionCommand command = request.ToAppLoginActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppLoginActionReply();
  }
}

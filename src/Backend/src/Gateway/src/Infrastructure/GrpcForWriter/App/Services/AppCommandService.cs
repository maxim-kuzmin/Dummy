namespace Makc.Dummy.Gateway.Infrastructure.GrpcForWriter.App.Services;

/// <summary>
/// Сервис команд приложения.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppCommandService(AppGrpcClient _grpcClient) : IAppCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AppLoginDTO>> Login(
    AppLoginActionCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var request = command.ToAppLoginActionRequest();

      var replyTask = _grpcClient.LoginAsync(
        request,
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToAppLoginActionDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

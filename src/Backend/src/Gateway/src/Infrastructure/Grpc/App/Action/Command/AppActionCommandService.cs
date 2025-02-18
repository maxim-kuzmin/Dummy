namespace Makc.Dummy.Gateway.Infrastructure.Grpc.App.Action.Command;

/// <summary>
/// Сервис команд действия приложения.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppActionCommandService(WriterAppGrpcClient _grpcClient) : IAppActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AppLoginActionDTO>> Login(
    AppLoginActionCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.LoginAsync(
        command.ToAppLoginActionRequestForGrpc(),
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

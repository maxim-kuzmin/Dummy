namespace Makc.Dummy.Gateway.Infrastructure.GrpcForMicroserviceWriter.Auth.Services;

/// <summary>
/// Сервис команд аутентификации.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AuthCommandService(AuthGrpcClient _grpcClient) : IAuthCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AuthLoginDTO>> Login(
    AuthLoginActionCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var request = command.ToAuthLoginActionRequest();

      var replyTask = _grpcClient.LoginAsync(
        request,
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToAuthLoginActionDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.Auth.Services;

/// <summary>
/// Сервис команд аутентификации.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AuthCommandService(AuthGrpcClient _grpcClient) : IAuthCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AuthLoginDTO>> Login(AuthLoginCommand command, CancellationToken cancellationToken)
  {
    try
    {
      var request = command.ToAuthLoginGrpcRequest();

      var task = _grpcClient.LoginAsync(request, cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAuthLoginDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

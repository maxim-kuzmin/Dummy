namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcClient.AppOutgoingEventPayload.Services;

/// <summary>
/// Сервис команд полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppOutgoingEventPayloadCommandService(
  AppOutgoingEventPayloadGrpcClient _grpcClient) : IAppOutgoingEventPayloadCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppOutgoingEventPayloadDeleteCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.DeleteAsync(
        command.ToAppOutgoingEventPayloadDeleteGrpcRequest(),
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success();
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  public async Task<Result<AppOutgoingEventPayloadSingleDTO>> Save(
    AppOutgoingEventPayloadSaveCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = command.IsUpdate
        ? _grpcClient.UpdateAsync(
          command.Data.ToAppOutgoingEventPayloadUpdateGrpcRequest(command.Id),
          cancellationToken: cancellationToken)
        : _grpcClient.CreateAsync(
          command.Data.ToAppOutgoingEventPayloadCreateGrpcRequest(),
          cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppOutgoingEventPayloadSingleDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.GrpcClient.AppIncomingEventPayload.Services;

/// <summary>
/// Сервис команд полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppIncomingEventPayloadCommandService(
  AppIncomingEventPayloadGrpcClient _grpcClient) : IAppIncomingEventPayloadCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppIncomingEventPayloadDeleteCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.DeleteAsync(
        command.ToAppIncomingEventPayloadDeleteGrpcRequest(),
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success();
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  public async Task<Result<AppIncomingEventPayloadSingleDTO>> Save(
    AppIncomingEventPayloadSaveCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = command.IsUpdate
        ? _grpcClient.UpdateAsync(
          command.Data.ToAppIncomingEventPayloadUpdateGrpcRequest(command.ObjectId),
          cancellationToken: cancellationToken)
        : _grpcClient.CreateAsync(
          command.Data.ToAppIncomingEventPayloadCreateGrpcRequest(),
          cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppIncomingEventPayloadSingleDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

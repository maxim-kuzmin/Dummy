namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.AppIncomingEvent.Services;

/// <summary>
/// Сервис команд входящего события приложения.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppIncomingEventCommandService(
  AppIncomingEventGrpcClient _grpcClient) : IAppIncomingEventCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppIncomingEventDeleteCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.DeleteAsync(
        command.ToAppIncomingEventDeleteGrpcRequest(),
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success();
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  public async Task<Result<AppIncomingEventSingleDTO>> Save(
    AppIncomingEventSaveCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = command.IsUpdate
        ? _grpcClient.UpdateAsync(
          command.Data.ToAppIncomingEventUpdateGrpcRequest(command.ObjectId),
          cancellationToken: cancellationToken)
        : _grpcClient.CreateAsync(
          command.Data.ToAppIncomingEventCreateGrpcRequest(),
          cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppIncomingEventSingleDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.AppOutgoingEvent.Services;

/// <summary>
/// Сервис команд исходящего события приложения.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppOutgoingEventCommandService(
  AppOutgoingEventGrpcClient _grpcClient) :IAppOutgoingEventCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppOutgoingEventDeleteCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.DeleteAsync(
        command.ToAppOutgoingEventDeleteGrpcRequest(),
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success();
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  public async Task<Result<AppOutgoingEventSingleDTO>> Save(
    AppOutgoingEventSaveCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = command.IsUpdate
        ? _grpcClient.UpdateAsync(
          command.Data.ToAppOutgoingEventUpdateGrpcRequest(command.Id),
          cancellationToken: cancellationToken)
        : _grpcClient.CreateAsync(
          command.Data.ToAppOutgoingEventCreateGrpcRequest(),
          cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppOutgoingEventSingleDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

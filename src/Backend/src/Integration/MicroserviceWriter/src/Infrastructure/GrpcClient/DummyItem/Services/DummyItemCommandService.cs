namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.DummyItem.Services;

/// <summary>
/// Сервис команд фиктивного предмета.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class DummyItemCommandService(DummyItemGrpcClient _grpcClient) : IDummyItemCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    DummyItemDeleteCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.DeleteAsync(
        command.ToDummyItemDeleteGrpcRequest(),
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success();
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  public async Task<Result<DummyItemSingleDTO>> Save(
    DummyItemSaveCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = command.IsUpdate
        ? _grpcClient.UpdateAsync(
          command.Data.ToDummyItemUpdateGrpcRequest(command.Id),
          cancellationToken: cancellationToken)
        : _grpcClient.CreateAsync(
          command.Data.ToDummyItemCreateGrpcRequest(),
          cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemSingleDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

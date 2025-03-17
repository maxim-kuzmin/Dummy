namespace Makc.Dummy.Gateway.Infrastructure.GrpcForReader.DummyItem.Services;

/// <summary>
/// Сервис команд фиктивного предмета.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class DummyItemCommandService(
  DummyItemGrpcClient _grpcClient) : IDummyItemCommandService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.CreateAsync(
        command.ToDummyItemCreateActionRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemSingleDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  /// <inheritdoc/>
  public async Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.DeleteAsync(
        command.ToDummyItemDeleteActionRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success();
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Update(
      DummyItemUpdateActionCommand command,
      CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.UpdateAsync(
        command.ToDummyItemUpdateActionRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemSingleDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

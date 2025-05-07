namespace Makc.Dummy.Gateway.Infrastructure.GrpcForMicroserviceReader.DummyItem.Services;

/// <summary>
/// Сервис запросов фиктивного предмета.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class DummyItemQueryService(
  AppSession _appSession,
  DummyItemGrpcClient _grpcClient) : IDummyItemQueryService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Get(
      DummyItemGetActionQuery query,
      CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.GetAsync(
        query.ToDummyItemGetActionRequest(),
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
  public async Task<Result<DummyItemListDTO>> GetList(
      DummyItemGetListActionQuery query,
      CancellationToken cancellationToken)
  {
    try
    {
      var accessToken = _appSession.AccessToken;
      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var request = query.ToDummyItemGetListActionRequest();

      var replyTask = _grpcClient.GetListAsync(
        request,
        headers: headers,
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemListDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}

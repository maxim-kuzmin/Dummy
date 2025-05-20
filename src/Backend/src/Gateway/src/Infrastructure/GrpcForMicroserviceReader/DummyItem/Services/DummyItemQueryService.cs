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
  public async Task<Result<DummyItemListDTO>> GetPage(
    DummyItemPageQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      var accessToken = _appSession.AccessToken;
      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var request = query.ToDummyItemGetListGrpcRequest();

      var task = _grpcClient.GetListAsync(
        request,
        headers: headers,
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemListDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> GetSingle(
    DummyItemSingleQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.GetAsync(
        query.ToDummyItemGetGrpcRequest(),
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

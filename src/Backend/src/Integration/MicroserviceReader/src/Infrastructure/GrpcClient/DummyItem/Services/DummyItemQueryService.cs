
namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.DummyItem.Services;

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
  public Task<Result<List<DummyItemSingleDTO>>> GetList(
    DummyItemListQuery query,
    CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemPageDTO>> GetPage(
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

      return Result.Success(reply.ToDummyItemPageDTO());
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

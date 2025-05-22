namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.AppIncomingEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppIncomingEventPayloadQueryService(
  AppSession _appSession,
  AppIncomingEventPayloadGrpcClient _grpcClient) : IAppIncomingEventPayloadQueryService
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadPageDTO>> GetPage(
    AppIncomingEventPayloadPageQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      var accessToken = _appSession.AccessToken;
      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var request = query.ToAppIncomingEventPayloadGetListGrpcRequest();

      var task = _grpcClient.GetListAsync(
        request,
        headers: headers,
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppIncomingEventPayloadPageDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadSingleDTO>> GetSingle(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.GetAsync(
        query.ToAppIncomingEventPayloadGetGrpcRequest(),
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

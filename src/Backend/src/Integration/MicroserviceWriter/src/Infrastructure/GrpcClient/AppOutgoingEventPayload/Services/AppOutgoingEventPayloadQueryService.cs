namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.AppOutgoingEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppOutgoingEventPayloadQueryService(
  AppSession _appSession,
  AppOutgoingEventPayloadGrpcClient _grpcClient) : IAppOutgoingEventPayloadQueryService
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadPageDTO>> GetPage(
    AppOutgoingEventPayloadPageQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      var accessToken = _appSession.AccessToken;
      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var request = query.ToAppOutgoingEventPayloadGetListGrpcRequest();

      var task = _grpcClient.GetListAsync(
        request,
        headers: headers,
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppOutgoingEventPayloadPageDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadSingleDTO>> GetSingle(
    AppOutgoingEventPayloadSingleQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.GetAsync(
        query.ToAppOutgoingEventPayloadGetGrpcRequest(),
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

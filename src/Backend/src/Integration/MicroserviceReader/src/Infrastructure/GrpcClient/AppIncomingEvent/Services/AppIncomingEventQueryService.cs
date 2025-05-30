namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.AppIncomingEvent.Services;

/// <summary>
/// Сервис запросов входящего события приложения.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppIncomingEventQueryService(
  AppSession _appSession,
  AppIncomingEventGrpcClient _grpcClient) : IAppIncomingEventQueryService
{
  /// <inheritdoc/>
  public async Task<Result<List<AppIncomingEventSingleDTO>>> GetList(
    AppIncomingEventListQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var request = query.ToAppIncomingEventGetListGrpcRequest();

      var task = _grpcClient.GetListAsync(
        request,
        headers: headers,
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppIncomingEventListDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPageDTO>> GetPage(
    AppIncomingEventPageQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var request = query.ToAppIncomingEventGetPageGrpcRequest();

      var task = _grpcClient.GetPageAsync(
        request,
        headers: headers,
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppIncomingEventPageDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventSingleDTO>> GetSingle(
    AppIncomingEventSingleQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.GetAsync(
        query.ToAppIncomingEventGetGrpcRequest(),
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

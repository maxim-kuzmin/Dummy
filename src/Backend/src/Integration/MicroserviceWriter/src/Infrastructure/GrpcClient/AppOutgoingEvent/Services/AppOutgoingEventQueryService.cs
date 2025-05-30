namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.AppOutgoingEvent.Services;

/// <summary>
/// Сервис запросов исходящего события приложения.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppOutgoingEventQueryService(
  AppSession _appSession,
  AppOutgoingEventGrpcClient _grpcClient) : IAppOutgoingEventQueryService
{
  /// <inheritdoc/>
  public async Task<Result<List<AppOutgoingEventSingleDTO>>> GetList(
    AppOutgoingEventListQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var request = query.ToAppOutgoingEventGetListGrpcRequest();

      var task = _grpcClient.GetListAsync(
        request,
        headers: headers,
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppOutgoingEventListDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPageDTO>> GetPage(
    AppOutgoingEventPageQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var request = query.ToAppOutgoingEventGetPageGrpcRequest();

      var task = _grpcClient.GetPageAsync(
        request,
        headers: headers,
        cancellationToken: cancellationToken);

      var reply = await task.ConfigureAwait(false);

      return Result.Success(reply.ToAppOutgoingEventPageDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventSingleDTO>> GetSingle(
    AppOutgoingEventSingleQuery query,
    CancellationToken cancellationToken)
  {
    try
    {
      var task = _grpcClient.GetAsync(
        query.ToAppOutgoingEventGetGrpcRequest(),
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

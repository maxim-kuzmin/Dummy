namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.AppOutgoingEventPayload;

/// <summary>
/// Сервис полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppOutgoingEventPayloadService(IMediator _mediator) : AppOutgoingEventPayloadServiceBase
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppOutgoingEventPayloadGetGrpcReply> Create(
    AppOutgoingEventPayloadCreateGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventPayloadSaveActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetGrpcReply();
  }

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<Empty> Delete(
    AppOutgoingEventPayloadDeleteGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventPayloadDeleteActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  /// <summary>
  /// Получить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppOutgoingEventPayloadGetGrpcReply> Get(
    AppOutgoingEventPayloadGetGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventPayloadGetActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetGrpcReply();
  }

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppOutgoingEventPayloadGetListGrpcReply> GetList(
    AppOutgoingEventPayloadGetListGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventPayloadGetListActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetListGrpcReply();
  }

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppOutgoingEventPayloadGetGrpcReply> Update(
    AppOutgoingEventPayloadUpdateGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventPayloadSaveActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetGrpcReply();
  }
}

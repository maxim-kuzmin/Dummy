namespace Makc.Dummy.MicroserviceReader.Infrastructure.Grpc.AppIncomingEventPayload;

/// <summary>
/// Сервис полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppIncomingEventPayloadService(IMediator _mediator) : AppIncomingEventPayloadServiceBase
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventPayloadGetGrpcReply> Create(
    AppIncomingEventPayloadCreateGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppIncomingEventPayloadSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventPayloadGetGrpcReply();
  }

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<Empty> Delete(AppIncomingEventPayloadDeleteGrpcRequest request, ServerCallContext context)
  {
    var command = request.ToAppIncomingEventPayloadDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  /// <summary>
  /// Получить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventPayloadGetGrpcReply> Get(
    AppIncomingEventPayloadGetGrpcRequest request,
    ServerCallContext context)
  {
    AppIncomingEventPayloadGetActionQuery query = request.ToAppIncomingEventPayloadGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventPayloadGetGrpcReply();
  }

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventPayloadGetListGrpcReply> GetList(
    AppIncomingEventPayloadGetListGrpcRequest request,
    ServerCallContext context)
  {
    AppIncomingEventPayloadGetListActionQuery query = request.ToAppIncomingEventPayloadGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventPayloadGetListGrpcReply();
  }

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventPayloadGetGrpcReply> Update(
    AppIncomingEventPayloadUpdateGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppIncomingEventPayloadSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventPayloadGetGrpcReply();
  }
}

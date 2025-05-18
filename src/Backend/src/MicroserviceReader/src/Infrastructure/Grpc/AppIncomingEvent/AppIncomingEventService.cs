namespace Makc.Dummy.MicroserviceReader.Infrastructure.Grpc.AppIncomingEvent;

/// <summary>
/// Сервис входящего события приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppIncomingEventService(IMediator _mediator) : AppIncomingEventServiceBase
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventGetGrpcReply> Create(
    AppIncomingEventCreateGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppIncomingEventSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventGetGrpcReply();
  }

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<Empty> Delete(AppIncomingEventDeleteGrpcRequest request, ServerCallContext context)
  {
    var command = request.ToAppIncomingEventDeleteActionCommand();

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
  public override async Task<AppIncomingEventGetGrpcReply> Get(
    AppIncomingEventGetGrpcRequest request,
    ServerCallContext context)
  {
    AppIncomingEventGetActionQuery query = request.ToAppIncomingEventGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventGetGrpcReply();
  }

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventGetListGrpcReply> GetList(
    AppIncomingEventGetListGrpcRequest request,
    ServerCallContext context)
  {
    AppIncomingEventGetListActionQuery query = request.ToAppIncomingEventGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventGetListGrpcReply();
  }

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventGetGrpcReply> Update(
    AppIncomingEventUpdateGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppIncomingEventSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventGetGrpcReply();
  }
}

namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.AppOutgoingEvent;

/// <summary>
/// Сервис исходящего события приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppOutgoingEventService(IMediator _mediator) : AppOutgoingEventServiceBase
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public sealed override async Task<AppOutgoingEventGetGrpcReply> Create(
    AppOutgoingEventCreateGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppOutgoingEventSaveActionRequest();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetGrpcReply();
  }

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public sealed override async Task<Empty> Delete(
    AppOutgoingEventDeleteGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppOutgoingEventDeleteActionRequest();

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
  public sealed override async Task<AppOutgoingEventGetGrpcReply> Get(
    AppOutgoingEventGetGrpcRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppOutgoingEventGetActionRequest();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetGrpcReply();
  }

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public sealed override async Task<AppOutgoingEventGetListGrpcReply> GetList(
    AppOutgoingEventGetListGrpcRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppOutgoingEventGetListActionRequest();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetListGrpcReply();
  }

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public sealed override async Task<AppOutgoingEventGetGrpcReply> Update(
    AppOutgoingEventUpdateGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppOutgoingEventSaveActionRequest();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetGrpcReply();
  }
}

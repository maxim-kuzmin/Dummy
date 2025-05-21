namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcServer.AppOutgoingEvent;

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
    var task = _mediator.Send(request.ToAppOutgoingEventSaveActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

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
    var task = _mediator.Send(request.ToAppOutgoingEventDeleteActionRequest(), context.CancellationToken);

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
  public sealed override async Task<AppOutgoingEventGetGrpcReply> Get(
    AppOutgoingEventGetGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppOutgoingEventGetActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

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
    var task = _mediator.Send(request.ToAppOutgoingEventGetListActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

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
    var task = _mediator.Send(request.ToAppOutgoingEventSaveActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetGrpcReply();
  }
}

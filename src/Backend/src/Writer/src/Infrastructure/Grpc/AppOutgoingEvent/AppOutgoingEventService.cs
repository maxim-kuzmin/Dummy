namespace Makc.Dummy.Writer.Infrastructure.Grpc.AppOutgoingEvent;

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
  public sealed override async Task<AppOutgoingEventGetActionReply> Create(
    AppOutgoingEventCreateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppOutgoingEventSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetActionReply();
  }

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public sealed override async Task<Empty> Delete(
    AppOutgoingEventDeleteActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppOutgoingEventDeleteActionCommand();

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
  public sealed override async Task<AppOutgoingEventGetActionReply> Get(
    AppOutgoingEventGetActionRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppOutgoingEventGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetActionReply();
  }

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public sealed override async Task<AppOutgoingEventGetListActionReply> GetList(
    AppOutgoingEventGetListActionRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppOutgoingEventGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetListActionReply();
  }

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public sealed override async Task<AppOutgoingEventGetActionReply> Update(
    AppOutgoingEventUpdateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppOutgoingEventSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetActionReply();
  }
}

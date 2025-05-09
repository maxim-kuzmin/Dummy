namespace Makc.Dummy.Reader.Infrastructure.Grpc.AppIncomingEventPayload;

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
  public override async Task<AppIncomingEventPayloadGetActionReply> Create(
    AppIncomingEventPayloadCreateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppIncomingEventPayloadSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventPayloadGetActionReply();
  }

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<Empty> Delete(AppIncomingEventPayloadDeleteActionRequest request, ServerCallContext context)
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
  public override async Task<AppIncomingEventPayloadGetActionReply> Get(
    AppIncomingEventPayloadGetActionRequest request,
    ServerCallContext context)
  {
    AppIncomingEventPayloadGetActionQuery query = request.ToAppIncomingEventPayloadGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventPayloadGetActionReply();
  }

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventPayloadGetListActionReply> GetList(
    AppIncomingEventPayloadGetListActionRequest request,
    ServerCallContext context)
  {
    AppIncomingEventPayloadGetListActionQuery query = request.ToAppIncomingEventPayloadGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventPayloadGetListActionReply();
  }

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventPayloadGetActionReply> Update(
    AppIncomingEventPayloadUpdateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppIncomingEventPayloadSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventPayloadGetActionReply();
  }
}

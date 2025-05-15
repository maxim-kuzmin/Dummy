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
  public override async Task<AppOutgoingEventPayloadGetActionReply> Create(
    AppOutgoingEventPayloadCreateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppOutgoingEventPayloadSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetActionReply();
  }

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<Empty> Delete(
    AppOutgoingEventPayloadDeleteActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppOutgoingEventPayloadDeleteActionCommand();

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
  public override async Task<AppOutgoingEventPayloadGetActionReply> Get(
    AppOutgoingEventPayloadGetActionRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppOutgoingEventPayloadGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetActionReply();
  }

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppOutgoingEventPayloadGetListActionReply> GetList(
    AppOutgoingEventPayloadGetListActionRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppOutgoingEventPayloadGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetListActionReply();
  }

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppOutgoingEventPayloadGetActionReply> Update(
    AppOutgoingEventPayloadUpdateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppOutgoingEventPayloadSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetActionReply();
  }
}

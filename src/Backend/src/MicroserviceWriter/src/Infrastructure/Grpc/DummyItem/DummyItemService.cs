namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Grpc.DummyItem;

/// <summary>
/// Сервис фиктивного предмета.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class DummyItemService(IMediator _mediator) : DummyItemServiceBase
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<DummyItemGetGrpcReply> Create(
    DummyItemCreateGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemSaveActionRequest();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetGrpcReply();
  }

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<Empty> Delete(DummyItemDeleteGrpcRequest request, ServerCallContext context)
  {
    var command = request.ToDummyItemDeleteActionRequest();

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
  public override async Task<DummyItemGetGrpcReply> Get(
    DummyItemGetGrpcRequest request,
    ServerCallContext context)
  {
    var query = request.ToDummyItemGetActionRequest();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetGrpcReply();
  }

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<DummyItemGetListGrpcReply> GetList(
    DummyItemGetListGrpcRequest request,
    ServerCallContext context)
  {
    var query = request.ToDummyItemGetListActionRequest();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetListGrpcReply();
  }

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context"></param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<DummyItemGetGrpcReply> Update(
    DummyItemUpdateGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemSaveActionRequest();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetGrpcReply();
  }
}

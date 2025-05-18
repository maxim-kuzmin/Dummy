namespace Makc.Dummy.MicroserviceReader.Infrastructure.Grpc.DummyItem;

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
    var command = request.ToDummyItemSaveActionCommand();

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
    var command = request.ToDummyItemDeleteActionCommand();

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
    DummyItemGetActionQuery query = request.ToDummyItemGetActionQuery();

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
    DummyItemGetListActionQuery query = request.ToDummyItemGetListActionQuery();

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
    var command = request.ToDummyItemSaveActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetGrpcReply();
  }
}

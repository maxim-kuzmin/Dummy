namespace Makc.Dummy.Writer.Infrastructure.Grpc.DummyItem;

/// <summary>
/// Сервис фиктивного предмета.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class DummyItemService(IMediator _mediator) : DummyItemServiceBase
{
  public override async Task<DummyItemGetActionReply> Create(
    DummyItemCreateActionRequest request,
    ServerCallContext context)
  {
    DummyItemCreateActionCommand command = request.ToDummyItemCreateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionReply();
  }

  public override async Task<Empty> Delete(DummyItemDeleteActionRequest request, ServerCallContext context)
  {
    DummyItemDeleteActionCommand command = request.ToDummyItemDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<DummyItemGetActionReply> Get(
    DummyItemGetActionRequest request,
    ServerCallContext context)
  {
    DummyItemGetActionQuery query = request.ToDummyItemGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionReply();
  }

  public override async Task<DummyItemGetListActionReply> GetList(
    DummyItemGetListActionRequest request,
    ServerCallContext context)
  {
    DummyItemGetListActionQuery query = request.ToDummyItemGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetListActionGrpcReply();
  }

  public override async Task<DummyItemGetActionReply> Update(
    DummyItemUpdateActionRequest request,
    ServerCallContext context)
  {
    DummyItemUpdateActionCommand command = request.ToDummyItemUpdateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionReply();
  }
}

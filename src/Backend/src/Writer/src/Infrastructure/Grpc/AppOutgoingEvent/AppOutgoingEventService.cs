namespace Makc.Dummy.Writer.Infrastructure.Grpc.AppOutgoingEvent;

/// <summary>
/// Сервис исходящего события приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppOutgoingEventService(IMediator _mediator) : AppOutgoingEventServiceBase
{
  public override async Task<AppOutgoingEventGetActionReply> Create(
    AppOutgoingEventCreateActionRequest request,
    ServerCallContext context)
  {
    AppOutgoingEventCreateActionCommand command = request.ToAppOutgoingEventCreateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetActionReply();
  }

  public override async Task<Empty> Delete(AppOutgoingEventDeleteActionRequest request, ServerCallContext context)
  {
    AppOutgoingEventDeleteActionCommand command = request.ToAppOutgoingEventDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<AppOutgoingEventGetActionReply> Get(
    AppOutgoingEventGetActionRequest request,
    ServerCallContext context)
  {
    AppOutgoingEventGetActionQuery query = request.ToAppOutgoingEventGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetActionReply();
  }

  public override async Task<AppOutgoingEventGetListActionReply> GetList(
    AppOutgoingEventGetListActionRequest request,
    ServerCallContext context)
  {
    AppOutgoingEventGetListActionQuery query = request.ToAppOutgoingEventGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetListActionGrpcReply();
  }

  public override async Task<AppOutgoingEventGetActionReply> Update(
    AppOutgoingEventUpdateActionRequest request,
    ServerCallContext context)
  {
    AppOutgoingEventUpdateActionCommand command = request.ToAppOutgoingEventUpdateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventGetActionReply();
  }
}

namespace Makc.Dummy.Writer.Infrastructure.Grpc.AppOutgoingEventPayload;

/// <summary>
/// Сервис полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppOutgoingEventPayloadService(IMediator _mediator) : AppOutgoingEventPayloadServiceBase
{
  public override async Task<AppOutgoingEventPayloadGetActionReply> Create(
    AppOutgoingEventPayloadCreateActionRequest request,
    ServerCallContext context)
  {
    AppOutgoingEventPayloadCreateActionCommand command = request.ToAppOutgoingEventPayloadCreateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetActionReply();
  }

  public override async Task<Empty> Delete(AppOutgoingEventPayloadDeleteActionRequest request, ServerCallContext context)
  {
    AppOutgoingEventPayloadDeleteActionCommand command = request.ToAppOutgoingEventPayloadDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<AppOutgoingEventPayloadGetActionReply> Get(
    AppOutgoingEventPayloadGetActionRequest request,
    ServerCallContext context)
  {
    AppOutgoingEventPayloadGetActionQuery query = request.ToAppOutgoingEventPayloadGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetActionReply();
  }

  public override async Task<AppOutgoingEventPayloadGetListActionReply> GetList(
    AppOutgoingEventPayloadGetListActionRequest request,
    ServerCallContext context)
  {
    AppOutgoingEventPayloadGetListActionQuery query = request.ToAppOutgoingEventPayloadGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetListActionGrpcReply();
  }

  public override async Task<AppOutgoingEventPayloadGetActionReply> Update(
    AppOutgoingEventPayloadUpdateActionRequest request,
    ServerCallContext context)
  {
    AppOutgoingEventPayloadUpdateActionCommand command = request.ToAppOutgoingEventPayloadUpdateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppOutgoingEventPayloadGetActionReply();
  }
}

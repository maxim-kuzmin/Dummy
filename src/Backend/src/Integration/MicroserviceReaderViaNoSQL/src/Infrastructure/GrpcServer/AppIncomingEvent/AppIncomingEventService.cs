namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.GrpcServer.AppIncomingEvent;

/// <summary>
/// Сервис входящего события приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppIncomingEventService(IMediator _mediator) : AppIncomingEventServiceBase
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context">Контекст.</param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventGetGrpcReply> Create(
    AppIncomingEventCreateGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppIncomingEventSaveActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventGetGrpcReply();
  }

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context">Контекст.</param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<Empty> Delete(AppIncomingEventDeleteGrpcRequest request, ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppIncomingEventDeleteActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  /// <summary>
  /// Получить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context">Контекст.</param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventGetGrpcReply> Get(
    AppIncomingEventGetGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppIncomingEventGetActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventGetGrpcReply();
  }

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context">Контекст.</param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventGetListGrpcReply> GetList(
    AppIncomingEventGetListGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppIncomingEventGetListActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventGetListGrpcReply();
  }

  /// <summary>
  /// Получить страницу.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context">Контекст.</param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventGetPageGrpcReply> GetPage(
    AppIncomingEventGetPageGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppIncomingEventGetPageActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventGetPageGrpcReply();
  }

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="request">Запрос gRPC.</param>
  /// <param name="context">Контекст.</param>
  /// <returns>Отклик gRPC.</returns>
  public override async Task<AppIncomingEventGetGrpcReply> Update(
    AppIncomingEventUpdateGrpcRequest request,
    ServerCallContext context)
  {
    var task = _mediator.Send(request.ToAppIncomingEventSaveActionRequest(), context.CancellationToken);

    var result = await task.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppIncomingEventGetGrpcReply();
  }
}

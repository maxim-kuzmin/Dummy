namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventDeleteActionHandler(IAppIncomingEventCommandService _service) :
  ICommandHandler<AppIncomingEventDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppIncomingEventDeleteActionRequest request, CancellationToken cancellationToken)
  {
    return _service.Delete(request.Command, cancellationToken);
  }
}

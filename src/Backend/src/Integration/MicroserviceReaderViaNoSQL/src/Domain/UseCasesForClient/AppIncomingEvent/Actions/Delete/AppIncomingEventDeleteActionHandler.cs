namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventDeleteActionHandler(IAppIncomingEventCommandService _service) :
  IRequestHandler<AppIncomingEventDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public ValueTask<Result> Handle(AppIncomingEventDeleteActionRequest request, CancellationToken cancellationToken)
  {
    return new ValueTask<Result>(_service.Delete(request.Command, cancellationToken));
  }
}

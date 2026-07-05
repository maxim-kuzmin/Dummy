namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventDeleteActionHandler(IAppOutgoingEventCommandService _service) :
  IRequestHandler<AppOutgoingEventDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public ValueTask<Result> Handle(AppOutgoingEventDeleteActionRequest request, CancellationToken cancellationToken)
  {
    return new ValueTask<Result>(_service.Delete(request.Command, cancellationToken));
  }
}

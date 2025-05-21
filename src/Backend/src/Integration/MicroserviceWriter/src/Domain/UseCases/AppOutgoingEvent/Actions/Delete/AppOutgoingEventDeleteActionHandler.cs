namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventDeleteActionHandler(IAppOutgoingEventCommandService _service) :
  ICommandHandler<AppOutgoingEventDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppOutgoingEventDeleteActionRequest request, CancellationToken cancellationToken)
  {
    return _service.Delete(request.Command, cancellationToken);
  }
}

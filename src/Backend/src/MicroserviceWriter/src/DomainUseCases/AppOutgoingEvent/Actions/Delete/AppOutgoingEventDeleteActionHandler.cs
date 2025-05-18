namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventDeleteActionHandler(IAppOutgoingEventCommandService _service) :
  ICommandHandler<AppOutgoingEventDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutgoingEventDeleteActionRequest request, CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

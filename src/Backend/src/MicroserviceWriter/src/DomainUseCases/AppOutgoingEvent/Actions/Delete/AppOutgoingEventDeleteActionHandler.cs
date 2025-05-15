namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventDeleteActionHandler(IAppOutgoingEventCommandService _service) :
  ICommandHandler<AppOutgoingEventDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutgoingEventDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

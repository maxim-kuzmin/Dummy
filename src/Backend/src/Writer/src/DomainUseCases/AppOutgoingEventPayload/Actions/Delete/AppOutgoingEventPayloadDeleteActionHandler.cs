namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadDeleteActionHandler(IAppOutgoingEventPayloadCommandService _service) :
  ICommandHandler<AppOutgoingEventPayloadDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(
    AppOutgoingEventPayloadDeleteActionCommand request,
    CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

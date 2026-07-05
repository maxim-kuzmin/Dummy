namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventDeleteActionHandler(IAppOutgoingEventCommandService _service) :
  IRequestHandler<AppOutgoingEventDeleteActionRequest, Result>
{
  /// <inheritdoc/>
  public async ValueTask<Result> Handle(AppOutgoingEventDeleteActionRequest request, CancellationToken cancellationToken)
  {
    var result = await _service.Delete(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

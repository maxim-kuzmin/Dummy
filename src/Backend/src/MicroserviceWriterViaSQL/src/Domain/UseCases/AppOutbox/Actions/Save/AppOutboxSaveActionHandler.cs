namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutbox.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению исходящего сообщения приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutboxSaveActionHandler(IAppOutboxCommandService _service) :
  ICommandHandler<AppOutboxSaveActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutboxSaveActionRequest request, CancellationToken cancellationToken)
  {
    var result = await _service.Save(request.Command, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutbox.Actions.Clear;

/// <summary>
/// Обработчик действия по очистке исходящих сообщений приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutboxClearActionHandler(IAppOutboxCommandService _service) :
  ICommandHandler<AppOutboxClearActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutboxClearActionRequest request, CancellationToken cancellationToken)
  {
    await _service.Clear(request.Command, cancellationToken).ConfigureAwait(false);

    return Result.NoContent();
  }
}

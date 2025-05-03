namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению исходящего сообщения приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutboxSaveActionHandler(IAppOutboxCommandService _service) :
  ICommandHandler<AppOutboxSaveActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutboxSaveActionCommand request, CancellationToken cancellationToken)
  {
    var result = await _service.Save(request, cancellationToken).ConfigureAwait(false);

    return result.Data;
  }
}

namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Обработчик действия выдаче исходящего сообщения приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutboxProduceActionHandler(IAppOutboxCommandService _service) :
  ICommandHandler<AppOutboxProduceActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutboxProduceActionCommand request, CancellationToken cancellationToken)
  {
    await _service.Produce(request, cancellationToken);

    return Result.NoContent();
  }
}

namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Обработчик действия выдаче исходящего сообщения приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutboxProduceActionHandler(IAppOutboxCommandService _service) :
  ICommandHandler<AppOutboxProduceActionRequest, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutboxProduceActionRequest request, CancellationToken cancellationToken)
  {
    await _service.Produce(request.Command, cancellationToken);

    return Result.NoContent();
  }
}

namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Обработчик действия выдаче исходящего сообщения приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutboxProduceActionHandler(IAppOutboxCommandService _service) :
  IRequestHandler<AppOutboxProduceActionRequest, Result>
{
  /// <inheritdoc/>
  public async ValueTask<Result> Handle(AppOutboxProduceActionRequest request, CancellationToken cancellationToken)
  {
    await _service.Produce(request.Command, cancellationToken).ConfigureAwait(false);

    return Result.NoContent();
  }
}

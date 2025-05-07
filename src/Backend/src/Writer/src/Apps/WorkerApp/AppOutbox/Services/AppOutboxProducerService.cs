namespace Makc.Dummy.Writer.Apps.WorkerApp.AppOutbox.Services;

/// <summary>
/// Сервис поставщика исходящих сообщений приложения.
/// </summary>
/// <param name="_appMessageBroker">Брокер сообщений приложения.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppOutboxProducerService(
  IAppMessageBroker _appMessageBroker,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    var connectionTask = _appMessageBroker.Connect(stoppingToken);

    if (stoppingToken.IsCancellationRequested)
    {
      return;
    }

    await connectionTask.ConfigureAwait(false);

    using var scope = _serviceScopeFactory.CreateScope();

    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

    AppOutboxProduceActionCommand command = new();

    await mediator.Send(command, stoppingToken).ConfigureAwait(false);
  }
}

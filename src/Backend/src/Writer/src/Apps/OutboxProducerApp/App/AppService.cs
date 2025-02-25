namespace Makc.Dummy.Writer.Apps.OutboxProducerApp.App;

/// <summary>
/// Сервис приложения.
/// </summary>
/// <param name="_appMessageProducer">Поставщик сообщений приложения.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppService(
  IAppMessageProducer _appMessageProducer,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await _appMessageProducer.Start(stoppingToken);

    using IServiceScope scope = _serviceScopeFactory.CreateScope();

    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

    AppOutboxProduceActionCommand command = new();

    await mediator.Send(command, stoppingToken);
  }
}

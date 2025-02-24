namespace Makc.Dummy.Reader.Apps.InboxConsumerApp.App;

/// <summary>
/// Сервис приложения.
/// </summary>
/// <param name="_appMessageConsumer">Потребитель сообщений приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppService(
  IAppMessageConsumer _appMessageConsumer,
  ILogger<AppService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      AppMessageReceiving[] receivings = [new(AppEventNameEnum.DummyItemChanged.ToString(), OnDummyItemChanged)];

      await _appMessageConsumer.Start(receivings, stoppingToken);

      using IServiceScope scope = _serviceScopeFactory.CreateScope();
    }
  }

  private Task OnDummyItemChanged(string message, CancellationToken cancellationToken)
  {
    _logger.LogInformation("MAKC:Received: {message}", message);

    return Task.CompletedTask;
  }
}

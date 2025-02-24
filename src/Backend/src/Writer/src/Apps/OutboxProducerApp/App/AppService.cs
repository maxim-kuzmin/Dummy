namespace Makc.Dummy.Writer.Apps.OutboxProducerApp.App;

/// <summary>
/// Сервис приложения.
/// </summary>
/// <param name="_appMessageProducer">Поставщик сообщений приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppService(
  IAppMessageProducer _appMessageProducer,
  ILogger<AppService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    const int timeoutToRepeat = 3000;

    while (!stoppingToken.IsCancellationRequested)
    {
      await _appMessageProducer.Start(stoppingToken);

      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      while (true)
      {
        try
        {
          AppMessageSending sending = new(AppEventNameEnum.DummyItemChanged.ToString(), DateTimeOffset.Now.ToString());

          await _appMessageProducer.Publish(sending, stoppingToken);

          await sending.TaskToComplete;
        }
        catch (Exception ex)
        {
          _logger.LogError(ex, "MAKC:Sending");
        }

        await Task.Delay(timeoutToRepeat, stoppingToken);
      }
    }
  }
}

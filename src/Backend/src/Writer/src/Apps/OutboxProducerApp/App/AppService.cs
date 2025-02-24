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
    while (!stoppingToken.IsCancellationRequested)
    {
      await Task.Run(() => _appMessageProducer.Start(stoppingToken), stoppingToken);

      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      while (true)
      {
        try
        {
          var onCompleted = new TaskCompletionSource();

          AppMessageSource source = new(onCompleted, DateTimeOffset.Now.ToString());

          await _appMessageProducer.Publish(source, stoppingToken);

          await onCompleted.Task;
        }
        catch (Exception ex)
        {
          _logger.LogError(ex, "MAKC: Source");
        }

        await Task.Delay(1000, stoppingToken);
      }
    }
  }
}

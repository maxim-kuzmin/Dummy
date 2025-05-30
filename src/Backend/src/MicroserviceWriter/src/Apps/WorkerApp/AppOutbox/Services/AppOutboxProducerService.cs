namespace Makc.Dummy.MicroserviceWriter.Apps.WorkerApp.AppOutbox.Services;

/// <summary>
/// Сервис поставщика исходящих сообщений приложения.
/// </summary>
/// <param name="_appMessageBroker">Брокер сообщений приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppOutboxProducerService(
  IAppMessageBroker _appMessageBroker,
  ILogger<AppOutboxProducerService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync start");

    _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Connect start");

    await _appMessageBroker.Connect(stoppingToken).ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Connect end");

    while (!stoppingToken.IsCancellationRequested)
    {
      using var scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Domain?.AppOutbox?.Producer);

      int eventMaxCountToPublish = Guard.Against.NegativeOrZero(options.EventMaxCountToPublish);
      int timeoutInMillisecondsToRepeat = Guard.Against.Negative(options.TimeoutInMillisecondsToRepeat);

      var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

      try
      {
        _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Produce start");

        AppOutboxProduceCommand command = new(EventMaxCountToPublish: eventMaxCountToPublish);

        _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Produce:Command: {command}", command);

        AppOutboxProduceActionRequest request = new(command);        

        await mediator.Send(request, stoppingToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Produce end");
      }
      catch (OperationCanceledException)
      {
        _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync canceled");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:AppOutboxProducerService:ExecuteAsync failed");
      }

      if (timeoutInMillisecondsToRepeat > 0)
      {
        await Task.Delay(timeoutInMillisecondsToRepeat, stoppingToken).ConfigureAwait(false);
      }
    }

    _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync end");
  }  
}

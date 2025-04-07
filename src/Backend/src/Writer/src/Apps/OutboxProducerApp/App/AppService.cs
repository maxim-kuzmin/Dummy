﻿namespace Makc.Dummy.Writer.Apps.OutboxProducerApp.App;

/// <summary>
/// Сервис приложения.
/// </summary>
/// <param name="_appMessageBus">Шина сообщений приложения.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppService(
  IAppMessageBus _appMessageBus,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    var connectionTask = _appMessageBus.Connect(stoppingToken);

    await connectionTask.ConfigureAwait(false);

    if (!connectionTask.IsCompletedSuccessfully)
    {
      return;
    }

    using IServiceScope scope = _serviceScopeFactory.CreateScope();

    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

    AppOutboxProduceActionCommand command = new();

    await mediator.Send(command, stoppingToken).ConfigureAwait(false);
  }
}

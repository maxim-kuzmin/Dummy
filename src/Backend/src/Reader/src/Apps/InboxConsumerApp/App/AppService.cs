namespace Makc.Dummy.Reader.Apps.InboxConsumerApp.App;

/// <summary>
/// Сервис приложения.
/// </summary>
/// <param name="_appMessageConsumer">Потребитель сообщений приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppService(
  IAppMessageConsumer _appMessageConsumer,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  private IMediator? _mediator;

  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    using IServiceScope scope = _serviceScopeFactory.CreateScope();

    _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

    MessageReceiving[] receivings = [new(AppEventNameEnum.DummyItemChanged.ToString(), OnMessageReceived)];

    await _appMessageConsumer.Start(receivings, stoppingToken);
  }

  private async Task OnMessageReceived(string sender, string message, CancellationToken cancellationToken)
  {
    Guard.Against.Null(_mediator);

    AppInboxConsumeActionCommand command = new(sender, message);

    await _mediator.Send(command, cancellationToken);
  }
}

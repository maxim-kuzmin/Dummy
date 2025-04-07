using Ardalis.GuardClauses;
using Confluent.Kafka;
using Makc.Dummy.Shared.Core.App.Config.Options.Sections;
using Microsoft.Extensions.Logging;

namespace Makc.Dummy.Shared.Infrastructure.Kafka.Message;

/// <summary>
/// Шина сообщений.
/// </summary>
public abstract class MessageBus : MessageBusBase
{
  private ConsumerConfig? _consumerConfig;

  private ProducerConfig? _producerConfig;

  private readonly ILogger _logger;

  protected string ConsumerGroupId { get; set; } = string.Empty;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  /// <param name="logger">Логгер.</param>
  public MessageBus(AppConfigOptionsKafkaSection? options, ILogger logger) : base(logger)
  {
    _logger = logger;

    Guard.Against.Null(options);

    _consumerConfig = new()
    {
      BootstrapServers = options.BootstrapServers
    };

    _producerConfig = new()
    {
      BootstrapServers = options.BootstrapServers
    };
  }

  /// <inheritdoc/>
  public override Task Connect(CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}

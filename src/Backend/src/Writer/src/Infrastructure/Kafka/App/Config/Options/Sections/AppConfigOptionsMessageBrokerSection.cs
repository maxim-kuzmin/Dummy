using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure;

namespace Makc.Dummy.Writer.Infrastructure.Kafka.App.Config.Options.Sections;

/// <summary>
/// Раздел брокера сообщений в параметрах конфигурации приложения.
/// </summary>
/// <param name="Producer">Поставщик.</param>
public record AppConfigOptionsMessageBrokerSection(ProducerConfig Producer) : AppConfigOptionsInfrastructureKafkaSection;

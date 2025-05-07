namespace Makc.Dummy.Reader.Infrastructure.Kafka.App.Config.Options.Sections;

/// <summary>
/// Раздел брокера сообщений в параметрах конфигурации приложения.
/// </summary>
/// <param name="Consumer">Потребитель.</param>
public record AppConfigOptionsMessageBrokerSection(ConsumerConfig Consumer) :
  AppConfigOptionsInfrastructureKafkaSection;

namespace Makc.Dummy.MicroserviceReader.DomainModel.AppIncomingEvent;

/// <summary>
/// Фабрика входящего события приложения.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppIncomingEventFactory(
  IAppIncomingEventResources _resources,
  AppIncomingEventEntitySettings _settings) : IAppIncomingEventFactory
{
  /// <inheritdoc/>
  public AppIncomingEventAggregate CreateAggregate(AppIncomingEventEntity? entityToChange = null)
  {
    return new(entityToChange, _resources, _settings);
  }
}

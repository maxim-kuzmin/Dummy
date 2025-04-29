namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEvent;

/// <summary>
/// Фабрика исходящего события приложения.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppOutgoingEventFactory(
  IAppOutgoingEventResources _resources,
  AppOutgoingEventEntitySettings _settings) : IAppOutgoingEventFactory
{
  /// <inheritdoc/>
  public AppOutgoingEventAggregate CreateAggregate(AppOutgoingEventEntity? entityToChange = null)
  {
    return new(entityToChange, _resources, _settings);
  }
}

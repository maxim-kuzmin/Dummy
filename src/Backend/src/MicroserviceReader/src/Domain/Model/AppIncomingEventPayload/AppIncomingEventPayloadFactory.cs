namespace Makc.Dummy.MicroserviceReader.Domain.Model.AppIncomingEventPayload;

/// <summary>
/// Фабрика полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppIncomingEventPayloadFactory(
  IAppIncomingEventPayloadResources _resources,
  AppIncomingEventPayloadEntitySettings _settings) : IAppIncomingEventPayloadFactory
{
  /// <inheritdoc/>
  public AppIncomingEventPayloadAggregate CreateAggregate(AppIncomingEventPayloadEntity? entityToChange = null)
  {
    return new(entityToChange, _resources, _settings);
  }
}

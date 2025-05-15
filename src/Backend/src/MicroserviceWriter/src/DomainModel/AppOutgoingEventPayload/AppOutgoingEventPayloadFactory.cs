namespace Makc.Dummy.MicroserviceWriter.DomainModel.AppOutgoingEventPayload;

/// <summary>
/// Фабрика полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class AppOutgoingEventPayloadFactory(
  IAppOutgoingEventPayloadResources _resources,
  AppOutgoingEventPayloadEntitySettings _settings) : IAppOutgoingEventPayloadFactory
{
  /// <inheritdoc/>
  public AppOutgoingEventPayloadAggregate CreateAggregate(AppOutgoingEventPayloadEntity? entityToChange = null)
  {
    return new(entityToChange, _resources, _settings);
  }
}

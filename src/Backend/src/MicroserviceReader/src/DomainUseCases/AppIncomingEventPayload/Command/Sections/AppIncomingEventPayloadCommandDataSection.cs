namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Command.Sections;

/// <summary>
/// Раздел данных команды полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="AppIncomingEventObjectId">Идентификатор объекта входящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadCommandDataSection(
  string AppIncomingEventObjectId,
  AppEventPayloadWithDataAsString Payload);

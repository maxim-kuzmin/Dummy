namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Command.Sections;

/// <summary>
/// Раздел данных команды полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="AppIncomingEventObjectId">Идентификатор объекта входящего события приложения.</param>
/// <param name="EventPayloadId">Идентификатор полезной нагрузки события.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadCommandDataSection(
  string AppIncomingEventObjectId,
  string EventPayloadId,
  AppEventPayloadWithDataAsString Payload);

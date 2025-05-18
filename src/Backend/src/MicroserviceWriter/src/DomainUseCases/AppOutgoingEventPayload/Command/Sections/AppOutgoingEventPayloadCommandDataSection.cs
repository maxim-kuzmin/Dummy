namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Command.Sections;

/// <summary>
/// Раздел данных команды фиктивного предмета.
/// </summary>
/// <param name="Name">Имя.</param>
public record AppOutgoingEventPayloadCommandDataSection(
  long AppOutgoingEventId,
  AppEventPayloadWithDataAsString Payload);

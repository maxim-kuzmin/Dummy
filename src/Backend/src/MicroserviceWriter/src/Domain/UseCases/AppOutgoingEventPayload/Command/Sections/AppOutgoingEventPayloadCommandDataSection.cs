namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Command.Sections;

/// <summary>
/// Раздел данных команды полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Name">Имя.</param>
public record AppOutgoingEventPayloadCommandDataSection(
  long AppOutgoingEventId,
  AppEventPayloadWithDataAsString Payload);

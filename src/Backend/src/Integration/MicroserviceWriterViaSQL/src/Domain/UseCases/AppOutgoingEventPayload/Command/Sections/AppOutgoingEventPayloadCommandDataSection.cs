namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Command.Sections;

/// <summary>
/// Раздел данных команды полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Name">Имя.</param>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppOutgoingEventPayloadCommandDataSection(
  long AppOutgoingEventId,
  AppEventPayloadWithDataAsString Payload);

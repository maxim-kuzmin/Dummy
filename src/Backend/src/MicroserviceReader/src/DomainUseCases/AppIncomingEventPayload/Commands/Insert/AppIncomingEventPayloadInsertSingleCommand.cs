namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Commands.Insert;

/// <summary>
/// Команда вставки единственной полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="AppIncomingEventObjectId">Идентификатор объекта входящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadInsertSingleCommand(
  string AppIncomingEventObjectId,
  AppEventPayloadWithDataAsString Payload);

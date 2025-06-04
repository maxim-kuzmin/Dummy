namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Commands;

/// <summary>
/// Команда удаления списка полезных нагрузок входящих событий приложения.
/// </summary>
/// <param name="ObjectIds">Идентификаторы объектов.</param>
/// <param name="AppIncomingEventObjectIds">Идентификаторы объектов входящих событий приложения.</param>
public record AppIncomingEventPayloadDeleteListCommand(
  List<string>? ObjectIds,
  List<string>? AppIncomingEventObjectIds);

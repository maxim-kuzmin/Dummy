namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppIncomingEventPayloadGetListActionRequest(AppIncomingEventPayloadListQuery Query) :
  IQuery<Result<List<AppIncomingEventPayloadSingleDTO>>>;

namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventPayloadGetListActionRequest(AppOutgoingEventPayloadListQuery Query) :
  IQuery<Result<List<AppOutgoingEventPayloadSingleDTO>>>;

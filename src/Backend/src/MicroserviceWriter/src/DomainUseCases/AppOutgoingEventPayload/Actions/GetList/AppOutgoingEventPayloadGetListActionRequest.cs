namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventPayloadGetListActionRequest(AppOutgoingEventPayloadPageQuery Query) :
  IQuery<Result<AppOutgoingEventPayloadListDTO>>;

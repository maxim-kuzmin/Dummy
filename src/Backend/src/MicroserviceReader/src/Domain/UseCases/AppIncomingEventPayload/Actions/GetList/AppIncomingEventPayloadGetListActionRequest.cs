namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppIncomingEventPayloadGetListActionRequest(AppIncomingEventPayloadPageQuery Query) :
  IQuery<Result<AppIncomingEventPayloadListDTO>>;

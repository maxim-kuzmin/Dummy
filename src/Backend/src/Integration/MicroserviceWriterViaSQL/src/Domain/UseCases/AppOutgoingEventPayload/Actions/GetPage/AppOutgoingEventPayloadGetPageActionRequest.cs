namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Actions.GetPage;

/// <summary>
/// Запрос действия по получению страницы полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventPayloadGetPageActionRequest(AppOutgoingEventPayloadPageQuery Query) :
  IQuery<Result<AppOutgoingEventPayloadPageDTO>>;

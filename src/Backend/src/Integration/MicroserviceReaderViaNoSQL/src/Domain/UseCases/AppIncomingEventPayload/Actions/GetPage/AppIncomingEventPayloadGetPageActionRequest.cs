namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.GetPage;

/// <summary>
/// Запрос действия по получению страницы полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppIncomingEventPayloadGetPageActionRequest(AppIncomingEventPayloadPageQuery Query) :
  IQuery<Result<AppIncomingEventPayloadPageDTO>>;

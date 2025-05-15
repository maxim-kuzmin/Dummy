namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppIncomingEventPayloadGetListActionQuery(AppIncomingEventPayloadPageQuery PageQuery) :
  AppIncomingEventPayloadListQuery(PageQuery),
  IQuery<Result<AppIncomingEventPayloadListDTO>>;

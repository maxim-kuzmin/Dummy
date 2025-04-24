namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppOutgoingEventPayloadGetListActionQuery(AppOutgoingEventPayloadPageQuery PageQuery) :
  AppOutgoingEventPayloadListQuery(PageQuery),
  IQuery<Result<AppOutgoingEventPayloadListDTO>>;
